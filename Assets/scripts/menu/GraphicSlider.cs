using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class GraphicSlider : MonoBehaviour
{
    int GLevel = 2;

    public Text Handle;

    public RenderPipelineAsset[] DetailLevel;

    void Start()
    {
        if (PlayerPrefs.HasKey("GraphicsLevel")) 
        {
            GLevel = PlayerPrefs.GetInt("GraphicsLevel");
            GetComponent<Slider>().value = GLevel;
        }
        else
        {
            PlayerPrefs.SetInt("GraphicsLevel", 2);

        }

        GetComponent<Slider>().value = GLevel;

        switch (GLevel)
        {
            case 0:
                Handle.text = "low";
                break;

            case 1:
                Handle.text = "medium";
                break;

            case 2:
                Handle.text = "high";
                break;

            default:
                break;
        }

    }



    public void Changed()
    {
        GLevel = ((int)GetComponent<Slider>().value);
        QualitySettings.SetQualityLevel(GLevel);
        QualitySettings.renderPipeline = DetailLevel[GLevel];
        Debug.Log(QualitySettings.renderPipeline.name);

        PlayerPrefs.SetInt("GraphicsLevel", GLevel);
        PlayerPrefs.Save();

        switch (GLevel)
        {
            case 0:
                Handle.text = "low";
                break;

            case 1:
                Handle.text = "medium";
                break;

            case 2:
                Handle.text = "high";
                break;

            default:
                break;
        }

    }

}
