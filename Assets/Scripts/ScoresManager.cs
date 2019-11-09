using UnityEngine;

public class ScoresManager : MonoBehaviour
{
    public static ScoresManager Instance { get; private set; }
    public int Scores = 1;
    public UnityEngine.UI.Text My_Text;

    public void Awake()
    {
        Instance = this;
    }

    public void AddCounter()
    {
        My_Text.text = "Кристалики: " + Scores++.ToString();
    }

}
