package controller.api;

import etu2070.annotation.restAPI;
import etu2070.annotation.url;
import model.Terrain;

public class TerrainController {

    @restAPI
    @url("terrain/liste-terrain.do")
    public Terrain[] listeTerrain(String id) throws Exception {
        return Terrain.getTerrain(id);
    }

}
