using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositGold : State
{
    enum Locations { goldmine, bank, saloon, home };

    override public void Enter(minerAI miner)
    {
        if (miner.GetLocation() != (int)Locations.bank)
            miner.ChangeLocation((int)Locations.bank);
        Debug.Log("Hi banker! I'd like to deposit these sweet old nuggets!");
        // Execute(miner);
    }

    override public void Execute(minerAI miner)
    {
        Debug.Log("Thats it!");
        miner.DepositGold();

        // Exit(miner);

    }

    override public void Exit(minerAI miner)
    {
        int savings = miner.GetSavings();
        Debug.Log("Great! I now have " + savings + " shiny nuggets!!");
    }
}
