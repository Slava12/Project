public var welcomeLabel : GUIStyle;
public var customSkin : GUISkin;
public var playGameRect : Rect;
public var optionsRect : Rect;
public var quitRect : Rect;


private var optionsMode = false;
private var menuMode = true;   //1
private var gameMode = false;  //1

public var _bulletImpulse : float = 300;
public var _shootDelay : float = 1;

function Awake(){
    DontDestroyOnLoad(this);
}

function OnGUI(){
    if (Input.GetKey(KeyCode.Escape)){  //2
        menuMode = true;                //1
        optionsMode = false;  
        Time.timeScale = 0;             //3
                
        if(gameMode){                   //1
            var ml = GameObject.Find("First Person Controller").GetComponent(MouseLook);  //4
            ml.enabled = false;  //4
        }
    }

    if(menuMode){
        if(!optionsMode){                       
                        
            //GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Welcome",welcomeLabel);
                
            GUI.skin = customSkin;
                        
            if(!gameMode){              //1
                if(GUI.Button(playGameRect, "Play Game")){
                    menuMode = false;   //1
                    gameMode = true;    //1
                    Time.timeScale = 1; //3
                    Application.LoadLevel(1);
                }
            }else{
                if(GUI.Button(playGameRect,"Resume")){
                    var _ml = GameObject.Find("First Person Controller").GetComponent(MouseLook);//4
                    _ml.enabled = true; //4
                    Time.timeScale = 1; //3
                    menuMode = false;   //1
                }
            }
                        
            if(GUI.Button(optionsRect,"Options")){
                optionsMode = true;
            }
                        
            if(GUI.Button(quitRect,"Quit")){
                Application.Quit();
            }
                        
        }else{
                                                        
            GUI.Label(new Rect(Screen.width / 2, 0, 50, 20),"Options",welcomeLabel);
                        
            GUI.skin = customSkin;
                        
            GUI.Label(new Rect(270, 75, 50, 20), "Bullet Impulse");
            _bulletImpulse = GUI.HorizontalSlider(new Rect(50, 100, 500, 20), _bulletImpulse,10,700);
            GUI.Label(new Rect(560, 95, 50, 20), _bulletImpulse.ToString());
                        
            GUI.Label(new Rect(270, 125, 50, 20), "Shoot Delay");
            _shootDelay = GUI.HorizontalSlider(new Rect(50, 150, 500, 20), _shootDelay,0.1,3);
            GUI.Label(new Rect(560, 145, 50, 20), _shootDelay.ToString());
                        
            if(GUI.Button(new Rect(20, 190, 100, 30), "<< Back")){
                optionsMode = false;
            }
        
        }
    }

}