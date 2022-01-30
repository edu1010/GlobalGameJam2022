using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mood : MonoBehaviour
{
    public Sprite Happy;
    public Sprite Normal;
    public Sprite sad;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

  public void ChangeModToHappy()
    {
        image.sprite = Happy;
    }
    public void ChangeModToNormal()
    {
        image.sprite = Normal;
    }
    public void ChangeModToSad()
    {
        image.sprite = sad;
    }
}
