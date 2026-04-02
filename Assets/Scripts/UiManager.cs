using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    
    public TextMeshProUGUI score;
    private float scoreCalc = 0;

    void Update()
    {
        scoreCalc += Time.deltaTime * 12 ;
        score.text = "Score: " + Mathf.Round(scoreCalc);

    }

    


}
