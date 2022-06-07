using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI countdownText;

float currentTime = 0f;
public float startingTime = 10f;
public int currentGold;
public TextMeshProUGUI ringText;


    // Start is called before the first frame update
    public void Start()
    {
        Time.timeScale = 1f;
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            if(currentTime==0){ //zaman 0 a eşitlendiğinde HealthManager componentinden Respawn çekildi
                GetComponent<HealthManager>().Respawn();

            }
        }
    }

    public void AddGold(int goldToAdd) //canvasa ring sayısı yazdırma
    {
        currentGold += goldToAdd;
        ringText.text = "Ring " + currentGold + "!";
    }
    
}

