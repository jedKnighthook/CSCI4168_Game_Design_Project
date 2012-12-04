using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponHandler : MonoBehaviour {

	private AbstractWeapon currentWeapon;
	private List<AbstractWeapon> weaponList;
	
	private AbstractOffhand currentOffhand;
	private List<AbstractOffhand> offhandList;
	
	private AbstractThrowable currentThrowable;
	private List<AbstractThrowable> throwableList;

	public int maxWeaponCapacity;
	public int maxOffhandCapacity;
	public int maxThrowableCapacity;
	
	/*
	 * Some simple list initialization
	 */
	public void Start() {
		weaponList = new List<AbstractWeapon>();
		offhandList = new List<AbstractOffhand>();
		throwableList = new List<AbstractThrowable>();
	}
	
	/*
	 * Add a weapon to your inventory
	 * Remove the currently held weapon if necessary to make room
	 */
	public void addWeapon(AbstractWeapon weapon) {
		if(weaponList.Count < maxWeaponCapacity) {
			DropWeapon(currentWeapon);
			weaponList.Add(weapon);
			currentWeapon = weapon;
		} else {
			// Add the weapon	
		}
	}
	public void DropWeapon(AbstractWeapon weapon) {
		if(weaponList.Count > 0) {
			// TODO: Drop the current weapon infront of the player
			
			weaponList.Remove(currentWeapon);
			currentWeapon = weaponList.ToArray()[0];
			
		}
	}
	
	public void AddOffhand(AbstractOffhand offhand) {
		
	}
	public void DropOffhand(AbstractOffhand offhand) {
		
	}
	
	public void AddThrowable(AbstractThrowable throwable) {
		
	}
	public void DropThrowable(AbstractThrowable throwable) {
		
	}
	
	/* *************************************************************
	 * Main weapon functions
	 * *************************************************************/
	public void FirePrimary() {
		currentWeapon.FirePrimary();
	}
	public void FireSecondary() {
		currentWeapon.FireSecondary();
	}
	public void FireOther(string command) {
		currentWeapon.FireOther(command);
	}
	public void Reload() {
		currentWeapon.Reload();	
	}

	/* ***********************************************************************
	 * Secondary Weapon functions
	 * These are currently only shells as there are no offhands or throwable
	 * weapons in game yet.
	 * ***********************************************************************/ 
	public void FireOffhand() {
		//currentOffhand.FireOffhand();
	}
	public void FireThrowable() {
		//currentThrowable.FireThrowable();
	}
	
}
