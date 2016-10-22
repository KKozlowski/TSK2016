using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour {
    public static Ui Me { get; private set; }

    public ParametersChoice parameterChoice;

    void Awake()
    {
        Me = this;
    }
}
