var delay = 0.5;




    function OnTriggerEnter (col : Collider) {
        Municion.CurrentAmmo += 10;
        yield WaitForSeconds(delay);
        Destroy(gameObject);
       
        
    }

        
            

