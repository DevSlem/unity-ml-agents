# Unity ML-Agents

You can use environments that i've developed when you train a reinforcement learning agent.

## Latest Environment

[RollerBall](https://github.com/DevSlem/unity-ml-agents/wiki/RollerBall)

![](/Images/rollerball.webp)

## Development Environment

* Unity Editor: 2021.3.6f1
* [Unity ML-Agents Toolkit: Release 19](https://github.com/Unity-Technologies/ml-agents/tree/release_19)
* Python: 3.7.13

If you want not to care about python environment settings, create an anaconda environment using this command:

```
conda env create -f conda_env.yaml
```

## Unity Environments

First of all, Open `Unity ML-Agents Project` in Unity Hub. After it, You can see environments directories in `Assets` folder. You can use them as a two ways to train.

1. build an environment as an executable file
2. directly interact with Unity Editor

You can see descriptions of environments in [Wiki](https://github.com/DevSlem/unity-ml-agents/wiki).

## Structure

* [config](/config/) - Training configuration files
* [Unity ML-Agents Project](/Unity%20ML-Agents%20Project/) - Unity ML-Agents project
