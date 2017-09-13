using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalState : State {

    enum Locations { goldmine, bank, saloon, home };

    override public void Enter(minerAI miner)
    {
        //Execute(miner);
    }

    override public void Execute(minerAI miner)
    {
        if (miner.GetThirst() >= 5 && miner.GetSpaceInPocket() < 2)
        {
            StateMachine this_StateMachine = miner.GetStateMachine();
            this_StateMachine.GlobalExecute();
        }
        
        //Exit(miner);

    }

    override public void Exit(minerAI miner)
    {
        
    }
}
