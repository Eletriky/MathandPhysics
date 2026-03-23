using UnityEngine;

public class Lab04_Grid : DrawableGrid
{
    public override void SetupScenes()
    {
        int sceneIndex;
        DrawableArrow newArrow;
        DrawableObject newGraph;

        sceneIndex = AddScene("Diamond");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);


        sceneIndex = AddScene("Diamond scale 20");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);
        newGraph.Scale = (Vector3.one * 20);

        sceneIndex = AddScene("Diamond scale 20, 10");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);
        newGraph.Scale = new Vector3(20, 10, 1);
        

        sceneIndex = AddScene("Diamond scale 20, 10. rotation 45");
        newGraph = new DrawableDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        newGraph.Rotation = 45 * Mathf.Deg2Rad;
        AddObjectToScene(sceneIndex, newGraph);

        AddScene("Empty Scene, Use Tab To Switch Scenes");
    }
}
