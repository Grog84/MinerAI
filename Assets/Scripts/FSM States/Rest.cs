using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : State {

    enum Locations { goldmine, bank, saloon, home };

    override public void Enter(minerAI miner)
    {
        if (miner.GetLocation() != (int)Locations.home)
            miner.ChangeLocation((int)Locations.home);
        Debug.Log("Home sweet hom..Finally some rest...time for bed!");

        // Execute(miner);
    }

    override public void Execute(minerAI miner)
    {
        Debug.Log("ZZZzzz...");
        miner.Rest();

        //if (miner.GetFatigue() != 0)
        //    Execute(miner);
        //else
        //    Exit(miner);

    }

    override public void Exit(minerAI miner)
    {
        Debug.Log("Good mornin' everyone! Let's get to the mine!");
    }
}
