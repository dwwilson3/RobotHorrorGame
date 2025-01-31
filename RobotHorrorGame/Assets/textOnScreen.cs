using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textOnScreen : MonoBehaviour
{
    
    public GameObject screenText;
    public GameObject character;
    public float timeLeft = 8.0f;
    public Text startText;
    public bool triggeredDecision = false;
    Transition t;
    //LifeManager lm;

    // Start is called before the first frame update
    void Start()
    {
        screenText.SetActive(false);
        character = GameObject.FindWithTag("Player");
        t = FindObjectOfType(typeof(Transition)) as Transition;
        //lm = FindObjectOfType(typeof(LifeManager)) as LifeManager;
        //Debug.Log("does this even work??");
    }

    void OnTriggerEnter(Collider p)
    {
        if (p.gameObject.tag == "Player")
        {
            screenText.SetActive(true);
            character.GetComponent<CameraMove>().enabled = false;
            triggeredDecision = true;
           


            //Debug.Log("The text should pop up bc of trigger");
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(8);
        screenText.SetActive(false);
        character.GetComponent<CameraMove>().enabled = true;
        //SceneManager.LoadScene(11);
        int index = SceneManager.GetActiveScene().buildIndex;
        //lm.RemoveLife();
        t.FadeToLevel(index + 6);
        //Destroy(screenText);
        //Destroy(gameObject);
    }

    void Update()
    {
        if (triggeredDecision)
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
           
        }
        
    }
}
