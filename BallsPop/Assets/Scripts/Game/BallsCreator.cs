using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCreator
{
    ViewportBounds viewportBounds;

    public BallsCreator(SceneSettings sceneSettings)
    {
        viewportBounds = sceneSettings.Get_ViewportBounds();
    }

    // Pooling
    // CreateBall
    // -GetPosition
    // -SetRandomRotation
}
