using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Jump", fileName = "Jump")]
public class JumpValues : ScriptableObject
{
    public float jumpforce = 20;
    public float speed = 20;
    public AnimationCurve jumpCurve;

    public void FakeUpdate(float deltaTime)
    {

    }
}
