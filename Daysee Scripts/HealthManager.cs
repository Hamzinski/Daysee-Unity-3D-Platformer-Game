using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public CharacterController thePlayer; 
    public int maxHealth;
    public int currentHealth;
    public float invincibilityLength;
    private float invincibilityCounter;
    public Renderer  playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;
    private bool isRespawning;
    private Vector3 respawnPoint;

    public float respawnLength;
    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;
    public int numOfHearts;
    [SerializeField] private Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Text sayac;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //thePlayer = FindObjectOfType<CharacterController>();
        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > numOfHearts){  //YILDIZLAR
            currentHealth = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++){
            if(i < currentHealth){
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts){
                hearts[i].enabled = true;
            }
            else{
                 hearts[i].enabled = false;
            } 
        }
        
        if(invincibilityCounter > 0)  // karakterin hasar aldıgında gidip gelmesi. respawnla beraber
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }
            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
        if(isFadeToBlack) //perdenin siyah açılıp kapanması
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }
        if(isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
    }
    public void HurtPlayer(int damage) // damage
    {
        if(invincibilityCounter <= 0)
        {
        currentHealth -= damage;
        if(currentHealth <= 0 )
        {
            Respawn();
        }
        else{
        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
        }
        }
    }
    /*public void Death()
    {
        HurtPlayer();
    }
    */

    public void Respawn()
    {
        //thePlayer.transform.position = respawnPoint;
        //currentHealth = maxHealth;
        if(!isRespawning)
        {
        StartCoroutine("RespawnCo");
        }

    }

    public IEnumerator RespawnCo()  //sahnenin kapanıp acılması, karakterin partikülle patlaması
    {
        isRespawning = true;
      
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeFromBlack = true;


        isRespawning = false;
        thePlayer.gameObject.SetActive(true);

        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;

         invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
        GetComponent<GameManager>().Start(); //Game manager scriptinden start fonksiyonunu çektik


    }   
    public void HealPlayer(int healAmount)  // can
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
