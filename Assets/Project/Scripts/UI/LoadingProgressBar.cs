using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    private Image _image;
    private void Awake()
    {
        _image = transform.GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = Loader.GetLoadingProgress();
    }
}
