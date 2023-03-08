


# # Fox Audio Manager
![Fox Icon](https://i.ibb.co/br7SPBG/q3866-Ct-SP28.jpg)
______________________
Проект с Audio Manager
Статус: В разработке.
Используется: [Unity 2021.3.11](https://unity3d.com/unity/whats-new/2021.3.11)
За основу взят : [RFG Audio](https://github.com/retro-fall-games/rfg-audio)

Официальная документация RFG Audio : [YouTube RFG Audio](https://www.youtube.com/watch?v=Qv9bM2KaRTY&list=PLpnpTHaLzeNWMW916duN_e_Y3AWG6-tdG)

Все необходимые файлы находиться в последнем релизе репозитория.

## Как установить?

Открываем  [Releases](https://github.com/IRecsRu/Fox-Audio/releases)  выбираем самый новый, и качаем файл [FoxAudioManager.unitypackage](https://github.com/IRecsRu/Fox-Audio/releases/tag/Main). Распаковываем в проекте.

## Как пользоваться?

Ищем  .../FoxAudioSystem/Prefabs/AudioInjector.prefab
Переносим на стартовую сцену.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/h97PSHx/bandicam-2023-03-08-17-54-34-470.jpg" alt="bandicam-2023-03-08-17-54-34-470" border="0"></a>

В качестве DI можно использовать любой удобный вам способ, в примере есть простой DI, для удобства тестирования.

Компонент  ***AudioInjector***  создает ***FoxAudioManager*** основу всей логики. В нем содержится вся необходимая для работы информация.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/DQ3Kz6Y/bandicam-2023-03-08-17-58-52-943.jpg" alt="bandicam-2023-03-08-17-58-52-943" border="0"></a>

Поля ***Audio Mixer Settings*** служат для указания какие микшеры использовать для работы с аудио. 

В поле ***Audio Case*** расположен ***Audio Case***

<a href="https://ibb.co/qnpBPkr"><img src="https://i.ibb.co/8B9MS67/bandicam-2023-03-08-18-11-42-186.jpg" alt="bandicam-2023-03-08-18-11-42-186" border="0"></a>

Тут храниться все доступные для использования аудио файлы.

Они делается на 3 типа.

 1. **Solo Audio** =  **Audio** = Проигрывает всего одну мелодию .   
 3. **Play List Audio** = **Playlist** = Хранит в себе несколько **Audio**, проигрывает их по очереди.    
 4. **Random Audio** = **RandomAudio** = Хранит в себе несколько **Audio**, проигрывает их в случайном порядке
 
 **Subgroup** которые аналогичны главному контейнеру, и служат исключительно для удобства менеджмента, и возможности создания кастомизации при необходимости.
 
 Prefabs проигрывателей 
 
 1. **Audio** = Для проигрывания одиночных аудио
 2. **Playlist** = Для проигрывания плейлистов аудио
 3. **RandomAudio** = Для проигрывания случайных аудио

Имя = Ключу, по которому запускается аудио.
То есть ключ **SoundTrack** = **"SoundTrack"**
Все ключи автоматически добавляться в список в классе AudioKey.
Позволяя избегать ошибок написания строковых ключей.
Пример  **AudioKey.SoundTrack**

**FoxAudioManager** является **DontDestroyOnLoad** _Singleton_
Вам необходимо добавить его в свою логику в самом начале игры.
Или через DI, или иным способом.

Далее логика работы проста 

```
AudioPlayer _audioPlayer = new AudioPlayer();

//Следует за целью
_audioPlayer.Play(AudioKey.Monetki, transform);
//Просто появляется в указанной позиции
_audioPlayer.Play(AudioKey.Monetki, transform.position);

bool PlayAudio(string key, Vector3 spawnPosition/Transform target)

string key = ключ по которому происходит поиск
Vector3 spawnPosition/Transform target = позиция или таргет

Для остановки 
_manager.Stop(string key)
```
## Инструменты для быстрого добавления аудио
**Данные инструменты в стадии отладки.**
Выбрав аудио файл появляется возможность быстрого его добавления в систему.  
Инструмент автоматически создает контейнер для файла, подстраивает его имя, в соответствии с шаблонам, и имеет возможность добавить этот файл в контейнер проигрывателя. 
Количество одновременно выделенных аудиофайлов не ограниченно.
<a href="https://ibb.co/zhJK2D0"><img src="https://i.ibb.co/jvR7ws1/bandicam-2023-03-08-18-24-29-561.jpg" alt="bandicam-2023-03-08-18-24-29-561" border="0"></a>

Такой результат вы получаем выбрав **Solo ClipData to Case**
<a href="https://ibb.co/ZJshTKQ"><img src="https://i.ibb.co/GJwVPkZ/bandicam-2023-03-08-18-30-55-333.jpg" alt="bandicam-2023-03-08-18-30-55-333" border="0"></a>
Папка создаться автоматически, в случае её отсутствия.
Но только по указанному в коде пути, перенос корневой паки в данный момент не предусмотрен и будет добавлен позже.


**Solo Audio Clip Data**
-
Имеет возможность синхронизации с другими **Solo Audio Clip Data** с таким же именем.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/Z2gn2PX/bandicam-2023-03-08-18-34-30-205.jpg" alt="bandicam-2023-03-08-18-34-30-205" border="0"></a>
______________________
**PlaylistData**
-
<a href="https://imgbb.com/"><img src="https://i.ibb.co/cQVB5fQ/Fox-Audio-Manager-0-6.png" alt="Fox-Audio-Manager-0-6" border="0"></a>
______________________
**RandomAudioData**
-
<a href="https://imgbb.com/"><img src="https://i.ibb.co/HVHQgxP/Fox-Audio-Manager-0-7.png" alt="Fox-Audio-Manager-0-7" border="0"></a>
