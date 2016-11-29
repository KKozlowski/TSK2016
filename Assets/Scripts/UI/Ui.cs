using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour {
    public static Ui Me { get; private set; }

    public ParametersChoice parameterChoice;
    public ProgressBar progressBar;

    public bool Shown
    {
        get { return GetComponent<CanvasGroup>().alpha > 0.98f; }
    }

    void Awake()
    {
        Me = this;
    }

    public void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }

    public void Show() {
        GetComponent<CanvasGroup>().alpha = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && GetComponent<CanvasGroup>())
        {
            if (Shown) Hide();
            else Show();
        }
    }
}
