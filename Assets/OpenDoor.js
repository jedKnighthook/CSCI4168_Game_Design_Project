#pragma strict
var clip: AnimationClip;

function Start () {

}

function OnTriggerEnter () 
{
	animation.Play(clip.name);
}