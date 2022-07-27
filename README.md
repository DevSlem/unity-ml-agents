# Unity ML-Agents

You can use environments that i've developed when you train a reinforcement learning agent.

## Latest Environment

[Windy Gridworld](https://github.com/DevSlem/unity-ml-agents/wiki/Windy-Gridworld)

![](/Images/windygridworld.webp)

## Development Environment

* Unity Editor: 2021.3.6f1
* [Unity ML-Agents Toolkit: Release 19](https://github.com/Unity-Technologies/ml-agents/tree/release_19)
* Python: 3.7.13

Install the `mlagents` Python package

```
conda install pytorch==1.11.0 torchvision==0.12.0 torchaudio==0.11.0 cudatoolkit=11.3 -c pytorch
python -m pip install mlagents==0.28.0
```

## Unity Environments

First of all, open `Unity ML-Agents Project` in Unity Hub. After it, you can see directories of environments in `Assets` folder. You can use them as a two ways to train.

1. build an environment as an executable file
2. directly interact with Unity Editor

You can see descriptions of environments in [Wiki](https://github.com/DevSlem/unity-ml-agents/wiki).

## Structure

* [config](/config/) - Training configuration files
* [Unity ML-Agents Project](/Unity%20ML-Agents%20Project/) - Unity ML-Agents project
