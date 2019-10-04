import UnityEngine.UI;

static var CurrentAmmo : int;
var InternalAmmo : int;
var AmmoDisplay : GameObject;



function Update () {
    InternalAmmo = CurrentAmmo;
    
    AmmoDisplay.GetComponent.<Text>().text = "" + InternalAmmo;
    
}