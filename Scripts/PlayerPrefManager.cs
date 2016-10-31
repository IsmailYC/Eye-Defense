using UnityEngine;
using System.Collections;

public static class PlayerPrefManager{
    public static bool GetShieldTip()
    {
        if (PlayerPrefs.HasKey("Shield Tip"))
        {
            if (PlayerPrefs.GetInt("Shield Tip") > 0)
                return true;
            else
                return false;
        }
        else
            return true;
    }

    public static bool GetSupportTip()
    {
        if (PlayerPrefs.HasKey("Support Tip"))
        {
            if (PlayerPrefs.GetInt("Support Tip") > 0)
                return true;
            else
                return false;
        }
        else
            return true;
    }

    public static bool GetPillTip()
    {
        if (PlayerPrefs.HasKey("Pill Tip"))
        {
            if (PlayerPrefs.GetInt("Pill Tip") > 0)
                return true;
            else
                return false;
        }
        else
            return true;
    }

    public static bool GetGoggleTip()
    {
        if (PlayerPrefs.HasKey("Goggle Tip"))
        {
            if (PlayerPrefs.GetInt("Goggle Tip") > 0)
                return true;
            else
                return false;
        }
        else
            return true;
    }

    public static bool GetStoreTip()
    {
        if (PlayerPrefs.HasKey("Store Tip"))
        {
            if (PlayerPrefs.GetInt("Store Tip") > 0)
                return true;
            else
                return false;
        }
        else
            return true;
    }

	public static int GetHighScore(){
		if (PlayerPrefs.HasKey ("HighScore"))
			return PlayerPrefs.GetInt ("HighScore");
		else
			return 0;
	}

	public static int GetShields(){
		if (PlayerPrefs.HasKey ("Shields"))
			return PlayerPrefs.GetInt ("Shields");
		else
			return 0;
	}

	public static int GetSupports(){
		if (PlayerPrefs.HasKey ("Supports"))
			return PlayerPrefs.GetInt ("Supports");
		else
			return 0;
	}

	public static int GetPills()
	{
		if (PlayerPrefs.HasKey ("Pills"))
			return PlayerPrefs.GetInt ("Pills");
		else
			return 0;
	}

	public static int GetGoggles()
	{
		if (PlayerPrefs.HasKey ("Goggles"))
			return PlayerPrefs.GetInt ("Goggles");
		else
			return 0;
	}

	public static int GetDNA()
	{
		if (PlayerPrefs.HasKey ("DNA"))
			return PlayerPrefs.GetInt ("DNA");
		else
			return 0;
	}

	public static int GetTimeBoostLvl()
	{
		if (PlayerPrefs.HasKey ("Time Boost Level"))
			return PlayerPrefs.GetInt ("Time Boost Level");
		else
			return 0;
	}

	public static int GetDamageBoostLvl()
	{
		if (PlayerPrefs.HasKey ("Damage Boost Level"))
			return PlayerPrefs.GetInt ("Damage Boost Level");
		else
			return 0;
	}

	public static int GetScoreBoostLvl()
	{
		if (PlayerPrefs.HasKey ("Score Boost Level"))
			return PlayerPrefs.GetInt ("Score Boost Level");
		else
			return 0;
	}

	public static int GetBarrierBoostLvl()
	{
		if (PlayerPrefs.HasKey ("Barrier Boost Level"))
			return PlayerPrefs.GetInt ("Barrier Boost Level");
		else
			return 0;
	}

	public static int GetSupportBoostLvl()
	{
		if (PlayerPrefs.HasKey ("Support Boost Level"))
			return PlayerPrefs.GetInt ("Support Boost Level");
		else
			return 0;
	}
	
    public static void SetShieldTip(bool tip)
    {
        if (tip)
            PlayerPrefs.SetInt("Shield Tip", 1);
        else
            PlayerPrefs.SetInt("Shield Tip", 0);
    }	

    public static void SetSupportTip(bool tip)
    {
        if (tip)
            PlayerPrefs.SetInt("Support Tip", 1);
        else
            PlayerPrefs.SetInt("Support Tip", 0);
    }

    public static void SetPillTip(bool tip)
    {
        if (tip)
            PlayerPrefs.SetInt("Pill Tip", 1);
        else
            PlayerPrefs.SetInt("Pill Tip", 0);
    }

    public static void SetGoggleTip(bool tip)
    {
        if (tip)
            PlayerPrefs.SetInt("Goggle Tip", 1);
        else
            PlayerPrefs.SetInt("Goggle Tip", 0);
    }

    public static void SetStoreTip(bool tip)
    {
        if (tip)
            PlayerPrefs.SetInt("Store Tip", 1);
        else
            PlayerPrefs.SetInt("Store Tip", 0);
    }

	public static void SetHighScore(int highscore)
	{
		PlayerPrefs.SetInt ("HighScore", highscore);
	}

	public static void SetShields(int shields)
	{
		PlayerPrefs.SetInt ("Shields", shields);
	}

	public static void SetSupports(int supports)
	{
		PlayerPrefs.SetInt ("Supports", supports);
	}

	public static void SetPills(int pills)
	{
		PlayerPrefs.SetInt ("Pills", pills);
	}

	public static void SetGoggles(int goggles)
	{
		PlayerPrefs.SetInt ("Goggles", goggles);
	}

	public static void SetDNA(int dna)
	{
		PlayerPrefs.SetInt ("DNA", dna);
	}

	public static void SetTimeBoostLvl(int level)
	{
		PlayerPrefs.SetInt ("Time Boost Level", level);
	}

	public static void SetDamageBoostLvl(int level)
	{
		PlayerPrefs.SetInt ("Damage Boost Level", level);
	}

	public static void SetScoreBoostLvl(int level)
	{
		PlayerPrefs.SetInt ("Score Boost Level", level);
	}

	public static void SetBarrierBoostLvl(int level)
	{
		PlayerPrefs.SetInt ("Barrier Boost Level", level);
	}

	public static void SetSupportBoostLvl(int level)
	{
		PlayerPrefs.SetInt ("Support Boost Level", level);
	}

	public static void ResetPrefs(bool highscore, bool boost, bool tips)
	{
		if (highscore)
			SetHighScore (0);
		if (boost) {
			SetTimeBoostLvl (0);
			SetScoreBoostLvl (0);
			SetDamageBoostLvl (0);
			SetBarrierBoostLvl (0);
			SetSupportBoostLvl (0);
		}
        if(tips)
        {
            SetGoggleTip(true);
            SetPillTip(true);
            SetShieldTip(true);
            SetStoreTip(true);
            SetSupportTip(true);
        }
		SetShields (0);
		SetSupports (0);
		SetPills (0);
		SetGoggles (0);
	}
}
