// Generated C++ file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
// Custom injected code entry point

#include "pch-il2cpp.h"

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include "il2cpp-appdata.h"
#include "helpers.h"
#include "Utilities.h"

using namespace app;

// Set the name of your log file here
extern const LPCWSTR LOG_FILE = L"il2cpp-log.txt";

// Custom injected code entry point
void Run()
{
    PMF::Setup();

    PMF::StartConsole();


    //PMF::WiatForSceneToLoad("Mian");

    auto gameScene = app::SceneManager_GetSceneAt(1, nullptr);
   
    auto* GameScene = &gameScene;


    if (Scene_get_isLoaded(((Scene__Boxed*)GameScene), nullptr)) {
        PMF::LogToConsole("Game Loaded");
    }
    

    
}

void OnSceneLoaded(const char sceneName[])
{
    char logMessage[] = "scene loaded ";
    strcat_s(logMessage, sceneName);
    PMF::LogToConsole(logMessage);

    auto gameObject = GameObject_CreatePrimitive(PrimitiveType__Enum::Cube, nullptr);

    PMF::LogToConsole("Created cube");

}