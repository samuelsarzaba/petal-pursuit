# Petal Pursuit

A top-down action-adventure game about love, flowers, and fighting monsters to create the perfect anniversary bouquet.

## Story

Navigate through dangerous territories to collect rare flowers for your partner's anniversary bouquet. Battle monsters protecting these precious blooms while racing against time to create the perfect floral arrangement.

## Features

- Top-down combat system
- Diverse flower collection mechanics
- Multiple endings based on bouquet composition:
  - True Love Ending
  - Friend Zone Ending
  - Breakup Ending
- Strategic flower arrangement system
- Monster battle mechanics
- Time management elements

## Project Structure

### Unity Project (`/unity/Petal Pursuit/`)

```
Assets/
├── Animations/        # Animation files and controllers
├── Art/              # Imported and processed art assets
│   ├── Characters/
│   ├── Environment/
│   ├── UI/
│   └── VFX/
├── Audio/            # Sound effects and music
├── Materials/        # Unity materials and shaders
├── Prefabs/         # Reusable game objects
├── Scenes/          # Unity scenes
└── Scripts/         # C# script files
```

### Source Assets (`/source-assets/`)

```
source-assets/
├── art/             # Original art files (PSD, AI, etc.)
│   ├── characters/
│   ├── environment/
│   ├── ui/
│   └── concepts/
├── audio/           # Original audio files (WAV, etc.)
└── documents/       # Design documents, references
```

## Asset Management

- **Source Assets**: Keep original art files (PSDs, AI files) in the `/source-assets` directory
- **Unity Assets**: Only store Unity-ready assets in the Unity project's Assets folder
- **Asset Naming Convention**:
  - Use lowercase with hyphens for files (e.g., `player-sprite.png`)
  - Use PascalCase for Unity assets (e.g., `PlayerController.cs`)

## Development Resources

- [Calendar & Asset Tracking](https://docs.google.com/spreadsheets/d/1WIojPnEhK8Bgvg_5DPAlzi6-EJKQpwVtQp7ntNSr4zI/edit?usp=sharing)

## Development Status

Currently in early development phase, focusing on combat mechanics and flower collection systems.

## Target Platform

- PC (Windows/Mac/Linux)
- Controller Support
