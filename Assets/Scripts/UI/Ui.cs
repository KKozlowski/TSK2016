using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour {
    public static Ui Me { get; private set; }

    public ParametersChoice parameterChoice;
    public ProgressBar progressBar;

    void Awake()
    {
        Me = this;
    }
}
