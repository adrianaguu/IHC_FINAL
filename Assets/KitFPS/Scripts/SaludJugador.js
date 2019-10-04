var health = 4;
var mainMenuSceneName : String;
var damage = 1;
var wait_time = 2;
var lock = 0;
 
 
function OnCollisionEnter(hit: Collision){
    if(hit.gameObject.tag == "Enemy" && lock == 0){
        DecreasingHealth();
    }
}
 
    function DecreasingHealth(){
        lock=1;
        health=health-damage;
        yield WaitForSeconds(wait_time);
        lock=0;
    }
 
    function Update(){
        if(health == 0){
            Application.LoadLevel(mainMenuSceneName);
        }
    }