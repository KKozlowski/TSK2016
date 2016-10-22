using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ParameterUnwindButton : MonoBehaviour
{
    public Button button;
    private List<ParameterLook> parameters = new List<ParameterLook>();
    public bool Opened { get; private set; }

    void Start()
    {
        button.onClick.AddListener(
            () => {
                //Debug.Log("CLICK");
                if (Opened) Close();
                else
                    Open();
            }
            );
    }

    public void Adopt(ParameterLook pl)
    {
        pl.transform.SetParent(transform, false);
        parameters.Add(pl);
        pl.GetComponent<Button>().onClick.AddListener(ReactToChildButton);
    }

    public void Open()
    {
        foreach (Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(true);
        }
        Opened = true;
    }

    public void Close()
    {
        foreach (Transform childTransform in transform) {
            childTransform.gameObject.SetActive(false);
        }
        Opened = false;
    }

    void ReactToChildButton()
    {
        Close();
    }
}
