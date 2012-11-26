using UnityEngine;
using System.Collections;

/*
 * This is the base class for all standard weapons.
 * To add a weapon, you must subclass this implement all abstract methods.
 * There are a number of public properties associated with starting parameters
 * which should be available for all weapons.
 * 
 * It is not necessary to implement all types of behaviours in a specific way.
 * However, all types of behaviours should be considered, even if it is simply
 * to declare in code that they are not used on the given weapon.
 * 
 * For example, a weapon need not have a secondary fireing fnuction, but the method
 * will still need to be subclassed and the associated ammo accessors will need to
 * return appropriate information reflecting the lack of secondary fire features.
 * 
 * 
 */
public abstract class AbstractWeapon : MonoBehaviour {
	
	/* ***********************************************************************
	 * Constants
	 * ***********************************************************************/
	public const int INFINITE_AMMO = -1;
	
	/* ***********************************************************************
	 * Public weapon settings
	 * ***********************************************************************/
	// Below are variable start parameters for weapons, set accordingly
	// These are to be coppied into the appropriate protected variables
	public int startingPrimaryAmmo;
	public int startingSecondaryAmmo;
	
	// This must be linked with the character's viewing transform, such
	// as the players camera, in order to get the direction in which to
	// cast rays for firing weapons
	public Transform cameraView;
	
	// Below are generally fixed parameters
	// There are no protected parameters as these should be the final values
	// Weapons which need these variables to change should create their own
	// internal private copies and use those.
	public int maxPrimaryAmmoCapacity;
	public int maxSecondaryAmmoCapacity;
	
	public int maxPrimaryClipSize;
	public int maxSecondaryClipSize;
	
	public int primaryFireRate;
	public int secondaryFireRate;
	
	public int primaryBaseDamage;
	public int secondaryBaseDamage;
	
	/* ***********************************************************************
	 * Protected variables
	 * These are used to maintain the weapons's current state without
	 * requiring a lot of getter/setter methods
	 * ***********************************************************************/
	protected int primaryAmmoReserve;
	protected int secondaryAmmoReserve;
	
	protected int primaryAmmoLoaded;
	protected int secondaryAmmoLoaded;
	
	protected GameObject targetObject;
	
	
	/* ***********************************************************************
	 * Public Weapon capabilities, these are only to be overridden
	 * ***********************************************************************/
	public abstract void FirePrimary();
	public abstract void FireSecondary();
	// FireOther is a method intended to allow for more than 2 methods of
	// firing with a single weapon as well as for special features such as
	// looking down the sights of a gun or using a scoped view.
	public abstract void FireOther(string command);
	// Generally used for reloading the primary
	public abstract void Reload();
	
	/* ***********************************************************************
	 * Public weapon information accessors
	 * ***********************************************************************/
	public int GetPrimaryAmmo() {
		return primaryAmmoLoaded + primaryAmmoReserve;
	}
	public int GetSecondaryAmmo() {
		return secondaryAmmoLoaded + secondaryAmmoReserve;
	}
	
	public void SetPrimaryAmmo(int ammo) {
		primaryAmmoReserve = ammo;
	}
	public void SetSecondaryAmmo(int ammo) {
		secondaryAmmoReserve = ammo;	
	}
	
	public GameObject GetTarget() {
		return targetObject;	
	}
	
	/* ***********************************************************************
	 * Initialization
	 * ***********************************************************************/
	
	void Start() {
		primaryAmmoLoaded = 0;
		secondaryAmmoLoaded = 0;
		
		primaryAmmoReserve = startingPrimaryAmmo;
		secondaryAmmoReserve = startingSecondaryAmmo;
	}
	
	/* ***********************************************************************
	 * Public weapon helper functions
	 * ***********************************************************************/
	
	/* 
	 * This function casts a ray from the weapon and returns the
	 * game objects with which it hits
	 * 
	 * Note: While the targetObject is a list suitable to hold multiple targets,
	 * the default implementation of this method will only cast a
	 * single, non-piercing ray. If a weapon requires multiple rays,
	 * such as a shotgun, or the ability to pass through multiple enemies,
	 * such as a sniper rifle, then this method must be overridden.
	 */
	public bool FindTarget() {
		if(cameraView != null) {
			RaycastHit hitInfo;
			if(Physics.Raycast(cameraView.position, cameraView.forward, out hitInfo, Mathf.Infinity, 0)) {
				targetObject = hitInfo.transform.gameObject;
				return true;
			}
		}
		
		return false;
	}
	
	/*
	 * Release the weapon's target.
	 * Note: It is required for the weapon to make this call to prevent
	 * subsequent weapon shots from potentially hitting a target which has since
	 * moved out of the target area.
	 */
	public void ReleaseTarget() {
		targetObject = null;	
	}
	
	/*
	 * Check if there is an object stored in the targetObject variable
	 * Check if it has an ObjectProperties component to apply damage to
	 * Apply Damage if both of these confitions are met
	 * 
	 * Negative values deal damage, positive values heal
	 */
	public void ApplyTargetHealthChange(float healthChange) {
		if(targetObject != null) {
			ObjectProperties targetProperties = targetObject.GetComponent<ObjectProperties>();
			if(targetProperties != null) {
				targetProperties.AddHealth(healthChange);	
			}
		}
	}
}
