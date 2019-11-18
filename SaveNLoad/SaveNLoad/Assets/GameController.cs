using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController gameControl;

    public int attack;
    public int defense;
    public int health;
    public int currentWeaponIndex;
    public List<Weapon> weapons;

    // Use this for initialization
    void Start () {
        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
            SetDefaultValue();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        attack  = 1;
        defense = 1;
        health  = 1;
        currentWeaponIndex = 0;
        Weapon weapon = new Weapon();
        weapon.attack = 0;
        weapons = new List<Weapon>();
        weapons.Add(weapon);
    }

    public void AddAttack()
    {
        attack++;
    }

    public void AddDefense()
    {
        defense++;
    }
	
    public void AddHealth()
    {
        health++;
    }

    public void AddWeaponAttack()
    {
        weapons[currentWeaponIndex].attack++;
    }

    public void AddWeapon()
    {
        Weapon weapon = new Weapon();
        weapon.attack = 0;
        weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (currentWeaponIndex + 1 == weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        else
        {
            currentWeaponIndex++;
        }
    }

    public void PreviousWeapon()
    {
        if (currentWeaponIndex == 0)
        {
            int lastWeapon = weapons.Count;
            if (lastWeapon > 0)
            {
                currentWeaponIndex = lastWeapon - 1;
            }
        }
        else
        {
            currentWeaponIndex--;
        }
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameInfo.data"))
        {
            throw new Exception("Game file doesn't exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.data", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        attack  = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health  = playerDataToLoad.health;
        file.Close();

        file = File.Open(Application.persistentDataPath + "weaponInfo.data", FileMode.Open);
        WeaponData weaponDataToLoad = (WeaponData)bf.Deserialize(file);
        currentWeaponIndex = weaponDataToLoad.currentWeaponIndex;
        weapons = weaponDataToLoad.weapons;
        file.Close();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.data", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack  = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health  = health;
        bf.Serialize(file, playerDataToSave);
        file.Close();

        file = File.Open(Application.persistentDataPath + "weaponInfo.data", FileMode.Create);
        WeaponData weaponDataToSave = new WeaponData();
        weaponDataToSave.currentWeaponIndex = currentWeaponIndex;
        weaponDataToSave.weapons = weapons;
        bf.Serialize(file, weaponDataToSave);
        file.Close();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack: " + attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense: " + defense, style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health: " + health, style);
        GUI.Label(new Rect(10, 210, 180, 80), "Weapon index: " + currentWeaponIndex, style);
        GUI.Label(new Rect(10, 260, 180, 80), "Weapon attack: " + weapons[currentWeaponIndex].attack, style);
    }
}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
}

[Serializable]
public class Weapon
{
    public int attack;
}

[Serializable]
class WeaponData
{
    public int currentWeaponIndex;
    public List<Weapon> weapons;
}