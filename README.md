# VR and AR Geovisualizations – Practice-Oriented Development Workflows Compared

This repository contains a Unity project developed as part of a Master Seminar Paper. It focuses on integrating and visualizing GeoJSON data, as well as displaying scanned 3D models in mobile AR applications.

## Table of Contents
1. [Overview](#overview)  
2. [Features](#features)  
3. [Requirements](#requirements)  
4. [License & Acknowledgments](#license--acknowledgments)  

---

## Overview
This project demonstrates how to load and process GeoJSON data in the Unity game engine. A second example also shows how to integrate a scanned 3D model (photogrammetry) including annotations into a mobile AR environment.

The goal is to present practice-oriented development workflows for VR/AR geovisualizations by combining established formats (like GeoJSON) and modern tools (such as AR Foundation).

---

## Features
- **Import and Processing of GeoJSON Files:**  
  - Uses the [GeoJSON.Net](https://github.com/GeoJSON-Net/GeoJSON.Net) library (via NuGet)  
  - Converts GeoJSON features (e.g., points, lines) into Unity GameObjects (marker prefabs, LineRenderer)

- **3D Scan Visualization in Mobile AR:**  
  - Integrates a scanned 3D model (GLTF) in an AR application (AR Foundation)  
  - Lets you place the model and annotations freely in the real environment  
  - Supports Android (Google ARCore) and iOS (ARKit)  

---

## Requirements
- **Unity** (tested with version 2022.3.55 or higher)  
- **Android or iOS SDK**, depending on the target platform  

---

## License & Acknowledgments
- This project is under the MIT License, unless otherwise noted.  
- The 3D scan of the Roman theater is provided by [@Arqueomodel3D](https://www.fab.com/listings/77b3732a-c9e9-4848-b7b0-6183d2e447e4). 
- Special thanks to the maintainers of [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity), [GeoJSON.Net](https://github.com/GeoJSON-Net/GeoJSON.Net), and [glTFast](https://github.com/atteneder/glTFast).
