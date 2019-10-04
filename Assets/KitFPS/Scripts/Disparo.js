
function Update () {

    if (Municion.CurrentAmmo >= 1){

	if(Input.GetButtonDown("Fire1")) {
		var gunsound : AudioSource = GetComponent.<AudioSource>();
		gunsound.Play();
		
	    Municion.CurrentAmmo -= 1;
	}
    }
}