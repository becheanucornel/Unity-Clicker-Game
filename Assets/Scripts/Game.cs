using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{

    //variables for UI
    public Text clicks;
    public Text multiply;
    public Text PGarden;
    public Text PFarm;
    public Text PFactory;
    public Text Money;

    //variables for the "One second function" in the Update
    private float waitTime = 1.0f;
    private float timer = 0.0f;

    //variables for multiplier funciton trigger
    private int potatosLow;
    private int potatosMid;
    private int potatosHigh;

    //variables for multiplier ammounts
    private int fewAmmount;
    private int someAmmount;
    private int lotsAmmount;

    //variable for the incrementation rate in the counter
    private int incremRate = 1;

    //variable for time incrementation
    private float playTime = 0.005f;
    private float pauseTime = 0f;

    //variables for incrementation update
    public int incremPotatoGarden = 0;
    public int incremPotatoFarm = 0;
    public int incremPotatoFactory = 0;
    public int PotatoGardenLimit;
    public int PotatoFarmLimit;
    public int PotatoFactoryLimit;

    //variables for credits
    public int credits = 0;

    //variables for difficulty
    public DifficultyDatabase difficultyDB;
    private int difficultyOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("difficultyOption"))
        {
            difficultyOption = 0;
        }
        else
        {
            Load();
        }

        UpdateDifficulty(difficultyOption);
    }

    private void UpdateDifficulty(int difficultyOption)
    {
        Difficulty difficulty = difficultyDB.GetDifficulty(difficultyOption);

        potatosLow = difficulty.potatosTL;
        potatosMid = difficulty.potatosTM;
        potatosHigh = difficulty.potatosTH;

        fewAmmount = difficulty.MultiplierFew;
        someAmmount = difficulty.MultiplierSome;
        lotsAmmount = difficulty.MultiplierLots;

        PotatoGardenLimit = difficulty.GardenLimit;
        PotatoFarmLimit = difficulty.FarmLimit;
        PotatoFactoryLimit = difficulty.FactoryLimit; 
    }

    private void Load()
    {
        difficultyOption = PlayerPrefs.GetInt("difficultyOption");
    }

    public void Increment()
    {
        GameManager.couter += incremRate;
    }

    public void Buy(int value)
    {
        if(value == 1 && GameManager.couter >= potatosLow)
        {
            GameManager.muliplier += fewAmmount;
            GameManager.couter -= potatosLow;
            incremPotatoGarden += 1;
        }
        
        if (value == 2 && GameManager.couter >= potatosMid)
        {
            GameManager.muliplier += someAmmount;
            GameManager.couter -= potatosMid;
            incremPotatoFarm += 1;
        }

        if (value == 3 && GameManager.couter >= potatosHigh)
        {
            GameManager.muliplier += lotsAmmount;
            GameManager.couter -= potatosHigh;
            incremPotatoFactory += 1;
        }
    }


    public void Update()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            Time.timeScale = playTime;

            Time.fixedDeltaTime = Time.timeScale;

            timer += Time.fixedDeltaTime;

            if (timer > waitTime)
            {
                GameManager.couter += GameManager.muliplier;

                timer = timer - waitTime;
            }
        }
        else
        {
            Time.timeScale = pauseTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.couter += incremRate;
        }

        if (incremPotatoGarden >= PotatoGardenLimit && incremPotatoFarm >= PotatoFarmLimit && incremPotatoFactory >= PotatoFactoryLimit)
        {
            incremRate += 2;
            GameManager.muliplier = 1;
            incremPotatoGarden -= PotatoGardenLimit;
            incremPotatoFarm -= PotatoFarmLimit;
            incremPotatoFactory -= PotatoFactoryLimit;
        }

        clicks.text = "Potatos: " + GameManager.couter;
        multiply.text = "Growth Rate: " + GameManager.muliplier;

        PGarden.text = "Bought " + incremPotatoGarden + " times";
        PFarm.text = "Bought " + incremPotatoFarm + " times";
        PFactory.text = "Bought " + incremPotatoFactory + " times";
    }
}