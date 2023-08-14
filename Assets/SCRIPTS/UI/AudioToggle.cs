using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Sprite _onSprite;
    
    private Image _imageAudio;

    private void Start()
    {
        _imageAudio=gameObject.GetComponent<Image>();
    }

    public void VolumeChanger()
    {
        if (AudioListener.volume == 0f)
        {
            OnSounds();
        }
        else
        {
            OffSounds();
        }
    }
    private void OnSounds()
    {
        AudioListener.volume = 1f;
        _imageAudio.sprite = _onSprite;
    }

    private void OffSounds()
    {
        AudioListener.volume = 0f;
        _imageAudio.sprite = _offSprite;
    }
}
