#pragma strict
var clip: AnimationClip;


function Update () 
{
	if (Input.GetKeyDown(KeyCode.E) ) 
	{
		animation.Play(clip.name);
	}
}