using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GraphUI : MonoBehaviour
{
    [SerializeField] private Transform leftBottom, rightTop;

    [SerializeField] private Text lastTimeText, lastYText, YTitle;

    [SerializeField] private LineRenderer line;

    public Results Source {
        get {
            return Simulation.Me.Presentation.Results;
        }
    }

    public char parameterCode = 'x';

    void Start()
    {
        StartCoroutine(UpdateEverySecond());
    }

    public void UpdateGraph()
    {
        lastTimeText.text = (Source.t.Last() * 1000).ToString("F5") + " ms";

        switch (parameterCode)
        {
            
            case 'v':
                YTitle.text = "Speed [m/s]";
                SetLine(Source.v);
                break;
            case 'a':
                YTitle.text = "Acceleration [m/s2]";
                SetLine(Source.a);
                break;
            case 'F':
                YTitle.text = "Force [N]";
                SetLine(Source.F);
                break;
            case 'P':
                YTitle.text = "Pressure [bar]";
                SetLine(Source.P);
                break;
            default:
            case 'x':
                YTitle.text = "Distance [m]";
                SetLine(Source.x);
                break;
        }
    }

    public void SetLine(List<double> data)
    {
        float max = (float)data.Max();
        float height = rightTop.localPosition.y - leftBottom.localPosition.y;
        float length = rightTop.localPosition.x - leftBottom.localPosition.x;
        float count = data.Count;

        lastYText.text = max.ToString("F4");

        Vector3[] positions = new Vector3[data.Count];
        for (int i = 0; i < data.Count; i++)
        {
            positions[i] = new Vector3(
                i / count * length,
                ((float)data[i])/max * height,
                0
                );
        }

        line.SetVertexCount(data.Count);
        line.SetPositions(positions);
    }

    IEnumerator UpdateEverySecond()
    {
        while (true)
        {
            UpdateGraph();
            yield return new WaitForSeconds(1f);
        }
    }
}
