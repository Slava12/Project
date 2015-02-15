#pragma strict

function OnMouseDown () { //1
    if(name=="Play Game") { Application.LoadLevel("project2"); } //2
    if(name=="Options") { }
    if(name=="Quit") { Application.Quit(); } //3
}

function OnMouseOver () { //1
    animation.Play(); //4
}