using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : State
{
    enum Locations { goldmine, bank, saloon, home };

    override public void Enter(minerAI miner)
    {
        if (miner.GetLocation() != (int)Locations.saloon)
            miner.ChangeLocation((int)Locations.saloon);
        Debug.Log("Let's see what this saloon has to offer! My throat is running dry!");
        //Execute(miner);
    }

    override public void Execute(minerAI miner)
    {
        Debug.Log("Ahh!! What a refreshing good'ol' whiskey!");
        miner.Drink();

        //Exit(miner);

    }

    override public void Exit(minerAI miner)
    {
        Debug.Log("Spent all my nugget in whiskey!! Better go back and diggin'!");
    }
}