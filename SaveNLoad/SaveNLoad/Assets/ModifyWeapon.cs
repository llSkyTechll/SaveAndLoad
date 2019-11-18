using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyWeapon : MonoBehaviour {

    public void IncreaseAttack()
    {
        GameController.gameControl.AddWeaponAttack();
    }

    public void AddWeapon()
    {
        GameController.gameControl.AddWeapon();
    }

    public void NextWeapon()
    {
        GameController.gameControl.NextWeapon();
    }

    public void PreviousWeapon()
    {
        GameController.gameControl.PreviousWeapon();
    }
}
