using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSaveNLoad : MonoBehaviour {

    public void Save()
    {
        GameController.gameControl.Save();
    }

    public void Load()
    {
        GameController.gameControl.Load();
    }
}
