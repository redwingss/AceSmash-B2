# AceSmash - Unity/C#

#### (Trello) 
* Planification des tâches - [Trello](https://trello.com/b/WByZtZO1/acesmash) 

## Pré-requis

#### (Unity)

* Installation de Unity Hub - [UnityHubSetup](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe?_gl=1*3wa2xf*_ga*NDU3MzUxMDgxLjE2MjE5NTU5OTI.*_ga_1S78EFL1W5*MTYyMTk2MDAzMy4yLjEuMTYyMTk2MDAzOS41NA..&_ga=2.12565108.1134175248.1621955992-457351081.1621955992)
* Installation de Unity - [Version 2020.3.3f1](https://unity3d.com/fr/get-unity/download?thank-you=update&download_nid=64639&os=Win)

#### (Assets)

* SunnyLand (https://assetstore.unity.com/packages/2d/characters/sunny-land-103349)
* TextMesh Pro (https://assetstore.unity.com/packages/tools/utilities/text-to-textmesh-pro-upgrade-tool-176732)

## Installation du joystick

* Gunicorn only runs on UNIX, therefore windows user will use WSL2, setup [instructions](https://docs.microsoft.com/fr-fr/windows/wsl/install-win10)
* install Python 3.9.4 (virtualenv recommended)
* install requirements with `pip install -r requirements.txt`
* launch server with either:
* `gunicorn --worker-class eventlet -w 1 app:app`
* `flask run
* `./start.sh`

## Lancer sur docker
You can also run arcade stick on Docker

* `docker-compose up` The folder will be mounted in docker compose so the server will relaunch on edit.

## Installation du jeu

Git clone `https://github.com/redwingss/AceSmash-B2-Ynov.git`

Pour rendre le jeu exécutable sur Windows/Mac/Linux, il faudra se rendre sur le projet via Unity.

`File -> Build and Run -> Choisir sur quel OS le jeu sera exécutable`

Lancer ensuite le jeu.

## Fonctionnalités

- 2 joueurs
- Point de vie
- Animation (Personnage)
- Déplacement 
- Système de saut
- Système de lancer (Objet)
- Menu
- Plateforme

## Idée protocole de communication (MQTT)

* Clavier 
* Joystick
* MQTT
