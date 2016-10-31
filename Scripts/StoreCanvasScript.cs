using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreCanvasScript : MonoBehaviour {
    
    public Text barrierBoostDisplay;
    public Text supportBoostDisplay;
    public Text timeBoostDisplay;
    public Text damageBoostDisplay;
    public Text scoreBoostDisplay;
    public Text shieldStoreDisplay;
    public Text supportStoreDisplay;
    public Text pillStoreDisplay;
    public Text dnaStoreDisplay;
    public GameObject storeTipPanel;

    bool tipped;
    int timeBoostLvl;
    int barrierBoostLvl;
    int supportBoostLvl;
    int damageBoostLvl;
    int scoreBoostLvl;
    int shields;
    int supports;
    int pills;
    int dna;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Cancel"))
        {
            if (tipped)
                tipped = false;
            else
                CloseStore();
        }
	}

    void OnEnable()
    {
        OpenStore();
    }

    public void OpenStore()
    {
        if (PlayerPrefManager.GetStoreTip())
        {
            storeTipPanel.SetActive(true);
            PlayerPrefManager.SetStoreTip(false);
            tipped = true;
        }
        GameManager.gm.ToggleMenuCanvas();
        timeBoostLvl = PlayerPrefManager.GetTimeBoostLvl();
        barrierBoostLvl = PlayerPrefManager.GetBarrierBoostLvl();
        supportBoostLvl = PlayerPrefManager.GetSupportBoostLvl();
        damageBoostLvl = PlayerPrefManager.GetDamageBoostLvl();
        scoreBoostLvl = PlayerPrefManager.GetScoreBoostLvl();
        dna = PlayerPrefManager.GetDNA();
        shields = PlayerPrefManager.GetShields();
        pills = PlayerPrefManager.GetPills();
        supports = PlayerPrefManager.GetSupports();
        dnaStoreDisplay.text = dna.ToString();
        barrierBoostDisplay.text = barrierBoostLvl.ToString();
        supportBoostDisplay.text = supportBoostLvl.ToString();
        timeBoostDisplay.text = timeBoostLvl.ToString();
        damageBoostDisplay.text = damageBoostLvl.ToString();
        scoreBoostDisplay.text = scoreBoostLvl.ToString();
        shieldStoreDisplay.text = shields.ToString();
        supportStoreDisplay.text = supports.ToString();
        pillStoreDisplay.text = pills.ToString();
        gameObject.SetActive(true);
    }

    public void CloseStore()
    {
        GameManager.gm.ReloadParameters(false);
        PlayerPrefManager.SetDNA(dna);
        PlayerPrefManager.SetBarrierBoostLvl(barrierBoostLvl);
        PlayerPrefManager.SetSupportBoostLvl(supportBoostLvl);
        PlayerPrefManager.SetTimeBoostLvl(timeBoostLvl);
        PlayerPrefManager.SetDamageBoostLvl(damageBoostLvl);
        PlayerPrefManager.SetScoreBoostLvl(scoreBoostLvl);
        PlayerPrefManager.SetShields(shields);
        PlayerPrefManager.SetSupports(supports);
        PlayerPrefManager.SetPills(pills);
        gameObject.SetActive(false);
        GameManager.gm.ToggleMenuCanvas();
    }

    public void UpgradeScore()
    {
        if (dna > 0)
        {
            if (scoreBoostLvl < 5)
            {
                dna--;
                dnaStoreDisplay.text = dna.ToString();
                scoreBoostLvl++;
                scoreBoostDisplay.text = scoreBoostLvl.ToString();
            }
        }
    }

    public void UpgradeTime()
    {
        if (dna > 0)
        {
            if (timeBoostLvl < 5)
            {
                dna--;
                dnaStoreDisplay.text = dna.ToString();
                timeBoostLvl++;
                timeBoostDisplay.text = timeBoostLvl.ToString();
            }
        }
    }

    public void UpgradeDamage()
    {
        if (dna > 0)
        {
            if (damageBoostLvl < 5)
            {
                dna--;
                dnaStoreDisplay.text = dna.ToString();
                damageBoostLvl++;
                damageBoostDisplay.text = damageBoostLvl.ToString();
            }
        }
    }

    public void UpgradeBarrier()
    {
        if (dna > 0)
        {
            if (barrierBoostLvl < 5)
            {
                dna--;
                dnaStoreDisplay.text = dna.ToString();
                barrierBoostLvl++;
                barrierBoostDisplay.text = barrierBoostLvl.ToString();
            }
        }
    }

    public void UpgradeSupport()
    {
        if (dna > 0)
        {
            if (supportBoostLvl < 5)
            {
                dna--;
                dnaStoreDisplay.text = dna.ToString();
                supportBoostLvl++;
                supportBoostDisplay.text = supportBoostLvl.ToString();
            }
        }
    }

    public void BuyShield()
    {
        if (dna > 0)
        {
            dna--;
            dnaStoreDisplay.text = dna.ToString();
            shields++;
            shieldStoreDisplay.text = shields.ToString();
        }
    }

    public void BuySupport()
    {
        if (dna > 0)
        {
            dna--;
            dnaStoreDisplay.text = dna.ToString();
            supports++;
            supportStoreDisplay.text = supports.ToString();
        }
    }

    public void BuyPill()
    {
        if (dna > 0)
        {
            dna--;
            dnaStoreDisplay.text = dna.ToString();
            pills++;
            pillStoreDisplay.text = pills.ToString();
        }
    }
}
