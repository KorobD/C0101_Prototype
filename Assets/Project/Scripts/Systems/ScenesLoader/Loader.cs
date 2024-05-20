using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    private class LoadingMonoBehaviour : MonoBehaviour {}
    
    private static Action _onLoaderCallback;
    private static AsyncOperation _loadingAsyncOperation;
    public static void Load(ScenesList scene)
    {
        //Set the loader callback action to load the target scene
        _onLoaderCallback = () =>
        {
            UnityEngine.GameObject loadingGameObject = new UnityEngine.GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));

        };
        
        //Load the loading scene
        SceneManager.LoadScene(ScenesList.Loading.ToString());
    }

    private static IEnumerator LoadSceneAsync(ScenesList scene)
    {
        yield return null;
        _loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        while (!_loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (_loadingAsyncOperation != null)
        {
            return _loadingAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        //Triggered after the first Update which lets the screen refresh
        //Execute the loader callback action which will load the target scene
        if (_onLoaderCallback != null)
        {
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }
}
