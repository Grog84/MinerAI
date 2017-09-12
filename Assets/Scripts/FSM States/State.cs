using System.Collections;
using System.Collections.Generic;

public interface IState {

    void Enter(minerAI miner);
    void Execute(minerAI miner);
    void Exit(minerAI miner);

}

public abstract class State
{
    public abstract void Enter(minerAI miner);

    public abstract void Execute(minerAI miner);

    public abstract void Exit(minerAI miner);
}
