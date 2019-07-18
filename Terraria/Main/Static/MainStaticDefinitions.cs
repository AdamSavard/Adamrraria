using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Terraria.Terraria.Constants;
namespace Terraria
{
    public partial class Main
    {
        public static int curRelease = 94;
        public static string versionNumber = "v1.2.3.1";
        public static string versionNumber2 = "v1.2.3.1";
        public static WorldSections sectionManager;
        public static bool ServerSideCharacter = false;
        public static string clientUUID;
        public static int maxMsg = 74;
        public static Effect pixelShader;
        public static Effect tileShader;
        public static int npcStreamSpeed = 60;
        public static int musicError = 0;
        public static bool dedServFPS = false;
        public static int dedServCount1 = 0;
        public static int dedServCount2 = 0;
        public static bool superFast = false;
        public static bool[] hairLoaded = new bool[123];
        public static bool[] wingsLoaded = new bool[25];
        public static bool[] goreLoaded = new bool[573];
        public static bool[] projectileLoaded = new bool[360];
        public static bool[] itemFlameLoaded = new bool[2289];
        public static bool[] backgroundLoaded = new bool[185];
        public static bool[] tileSetsLoaded = new bool[314];
        public static bool[] wallLoaded = new bool[145];
        public static bool[] NPCLoaded = new bool[369];
        public static bool[] armorHeadLoaded = new bool[160];
        public static bool[] armorBodyLoaded = new bool[168];
        public static bool[] armorLegsLoaded = new bool[103];
        public static bool[] accHandsOnLoaded = new bool[18];
        public static bool[] accHandsOffLoaded = new bool[11];
        public static bool[] accBackLoaded = new bool[8];
        public static bool[] accFrontLoaded = new bool[5];
        public static bool[] accShoesLoaded = new bool[15];
        public static bool[] accWaistLoaded = new bool[11];
        public static bool[] accShieldLoaded = new bool[5];
        public static bool[] accNeckLoaded = new bool[7];
        public static bool[] accFaceLoaded = new bool[8];
        public static bool[] accballoonLoaded = new bool[11];
        public static Vector2[] offHandOffsets = new Vector2[]
		{
			new Vector2(14f, 20f),
			new Vector2(14f, 20f),
			new Vector2(14f, 20f),
			new Vector2(14f, 18f),
			new Vector2(14f, 20f),
			new Vector2(16f, 4f),
			new Vector2(16f, 16f),
			new Vector2(18f, 14f),
			new Vector2(18f, 14f),
			new Vector2(18f, 14f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f),
			new Vector2(14f, 14f),
			new Vector2(14f, 14f),
			new Vector2(12f, 14f),
			new Vector2(14f, 16f),
			new Vector2(16f, 16f),
			new Vector2(16f, 16f)
		};
        public static float zoomX;
        public static float zoomY;
        public static float sunCircle;
        public static int BlackFadeIn = 0;
        public static bool noWindowBorder = false;
        public static int ugBack = 0;
        public static int oldUgBack = 0;
        public static int[] bgFrame = new int[1];
        public static int[] bgFrameCounter = new int[1];
        public static bool skipMenu = false;
        public static bool verboseNetplay = false;
        public static bool stopTimeOuts = false;
        public static bool showSpam = false;
        public static bool showItemOwner = false;
        public static int oldTempLightCount = 0;
        public static bool[] nextNPC = new bool[369];
        public static int musicBox = -1;
        public static int musicBox2 = -1;
        public static byte hbPosition = 1;
        public static bool cEd = false;
        public static float wFrCounter = 0f;
        public static float wFrame = 0f;
        public static float upTimer;
        public static float upTimerMax;
        public static float upTimerMaxDelay;
        public static float[] drawTimer = new float[10];
        public static float[] drawTimerMax = new float[10];
        public static float[] drawTimerMaxDelay = new float[10];
        public static float[] renderTimer = new float[10];
        public static float[] lightTimer = new float[10];
        public static bool drawDiag = false;
        public static bool drawRelease = false;
        public static int debugToggle = 0;
        public static bool toggleRelease = false;
        public static bool drawBetterDebug = false;
        public static bool betterDebugRelease = false;
        public static bool renderNow = false;
        public static bool drawToScreen = false;
        public static bool targetSet = false;
        public static int mouseX;
        public static int mouseY;
        public static bool mouseLeft;
        public static bool mouseRight;
        public static float essScale = 1f;
        public static int essDir = -1;
        public static float[] cloudBGX = new float[2];
        public static float cloudBGAlpha;
        public static float cloudBGActive;
        public static int[] cloudBG = new int[]
		{
			112,
			113
		};
        public static int[] treeMntBG = new int[2];
        public static int[] treeBG = new int[3];
        public static int[] corruptBG = new int[3];
        public static int[] jungleBG = new int[3];
        public static int[] snowMntBG = new int[2];
        public static int[] snowBG = new int[3];
        public static int[] hallowBG = new int[3];
        public static int[] crimsonBG = new int[3];
        public static int[] desertBG = new int[2];
        public static int oceanBG;
        public static int[] treeX = new int[4];
        public static int[] treeStyle = new int[4];
        public static int[] caveBackX = new int[4];
        public static int[] caveBackStyle = new int[4];
        public static int iceBackStyle;
        public static int hellBackStyle;
        public static int jungleBackStyle;
        public static string debugWords = "";
        public static bool gamePad = false;
        public static bool xMas = false;
        public static bool halloween = false;
        public static int snowDust = 0;
        public static bool chTitle = false;
        public static bool hairWindow = false;
        public static bool clothesWindow = false;
        public static bool ingameOptionsWindow = false;
        public static int keyCount = 0;
        public static string[] keyString = new string[10];
        public static int[] keyInt = new int[10];
        public static byte gFade = 0;
        public static float gFader = 0f;
        public static byte gFadeDir = 1;
        public static bool netDiag = false;
        public static int txData = 0;
        public static int rxData = 0;
        public static int txMsg = 0;
        public static int rxMsg = 0;
        public static int[] rxMsgType = new int[Main.maxMsg];
        public static int[] rxDataType = new int[Main.maxMsg];
        public static int[] txMsgType = new int[Main.maxMsg];
        public static int[] txDataType = new int[Main.maxMsg];
        public static float uCarry = 0f;
        public static bool drawSkip = false;
        public static int fpsCount = 0;
        public static Stopwatch fpsTimer = new Stopwatch();
        public static Stopwatch updateTimer = new Stopwatch();
        public static int fountainColor = -1;
        public static bool showSplash = true;
        public static bool ignoreErrors = true;
        public static string defaultIP = "";
        public static int dayRate = 1;
        public static int maxScreenW = 1920;
        public static int minScreenW = 800;
        public static int maxScreenH = 1200;
        public static int minScreenH = 600;
        public static float iS = 1f;
        public static bool render = false;
        public static int qaStyle = 0;
        public static int zoneX = 99;
        public static int zoneY = 87;
        public static float harpNote = 0f;
        public static bool[] projHostile = new bool[360];
        public static bool[] pvpBuff = new bool[104];
        public static bool[] vanityPet = new bool[104];
        public static bool[] lightPet = new bool[104];
        public static bool[] meleeBuff = new bool[104];
        public static bool[] debuff = new bool[104];
        public static string[] buffName = new string[104];
        public static string[] buffTip = new string[104];
        public static int maxMP = 10;
        public static string[] recentWorld = new string[Main.maxMP];
        public static string[] recentIP = new string[Main.maxMP];
        public static int[] recentPort = new int[Main.maxMP];
        public static bool shortRender = true;
        public static bool owBack = true;
        public static int quickBG = 2;
        public static int bgDelay = 0;
        public static int bgStyle = 0;
        public static float[] bgAlpha = new float[10];
        public static float[] bgAlpha2 = new float[10];
        public static int wof = -1;
        public static int wofT;
        public static int wofB;
        public static int wofF = 0;
        public static int offScreenRange = 200;
        public static int maxMapUpdates = 250000;
        public static bool refreshMap = false;
        public static int loadMapLastX = 0;
        public static bool loadMapLock = false;
        public static bool loadMap = false;
        public static bool mapReady = false;
        public static int textureMaxWidth = 2000;
        public static int textureMaxHeight = 1800;
        public static bool updateMap = false;
        public static int mapMinX = 0;
        public static int mapMaxX = 0;
        public static int mapMinY = 0;
        public static int mapMaxY = 0;
        public static int mapTimeMax = 30;
        public static int mapTime = Main.mapTimeMax;
        public static bool clearMap;
        public static int mapTargetX = 5;
        public static int mapTargetY = 2;
        public static bool[,] initMap = new bool[Main.mapTargetX, Main.mapTargetY];
        public static Texture2D colorSliderTexture;
        public static Texture2D colorBarTexture;
        public static Texture2D colorBlipTexture;
        public static bool mapInit = false;
        public static bool mapEnabled = true;
        public static int mapStyle = 1;
        public static float grabMapX = 0f;
        public static float grabMapY = 0f;
        public static int miniMapX = 0;
        public static int miniMapY = 0;
        public static int miniMapWidth = 0;
        public static int miniMapHeight = 0;
        public static float mapMinimapScale = 1.25f;
        public static float mapMinimapAlpha = 1f;
        public static float mapOverlayScale = 2.5f;
        public static float mapOverlayAlpha = 0.35f;
        public static bool mapFullscreen = false;
        public static bool resetMapFull = false;
        public static float mapFullscreenScale = 4f;
        public static Vector2 mapFullscreenPos = new Vector2(-1f, -1f);
        public static int renderCount = 99;
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        private static Stopwatch saveTime = new Stopwatch();
        public static MouseState mouseState = Mouse.GetState();
        public static MouseState oldMouseState = Mouse.GetState();
        public static KeyboardState keyState = Keyboard.GetState();
        public static Color mcColor = new Color(125, 125, 255);
        public static Color hcColor = new Color(200, 125, 255);
        public static Color highVersionColor = new Color(255, 255, 0);
        public static Color errorColor = new Color(255, 0, 0);
        public static Color bgColor;
        public static bool mouseHC = false;
        public static bool craftingHide = false;
        public static bool armorHide = false;
        public static float craftingAlpha = 1f;
        public static float armorAlpha = 1f;
        public static float[] buffAlpha = new float[104];
        public static Item trashItem = new Item();
        public static bool hardMode = false;

        public static bool drawScene = false;
        public static Vector2 sceneWaterPos = default(Vector2);
        public static Vector2 sceneTilePos = default(Vector2);
        public static Vector2 sceneTile2Pos = default(Vector2);
        public static Vector2 sceneWallPos = default(Vector2);
        public static Vector2 sceneBackgroundPos = default(Vector2);
        public static bool maxQ = true;
        public static float gfxQuality = 1f;
        public static float gfxRate = 0.01f;

        public static int DiscoR = 255;
        public static int DiscoB = 0;
        public static int DiscoG = 0;
        public static int teamCooldown = 0;
        public static int teamCooldownLen = 300;
        public static bool gamePaused = false;
        public static bool gameInactive = false;
        public static int updateTime = 0;
        public static int drawTime = 0;
        public static int uCount = 0;
        public static int updateRate = 0;
        public static int frameRate = 0;
        public static bool RGBRelease = false;
        public static bool qRelease = false;
        public static bool netRelease = false;
        public static bool frameRelease = false;
        public static bool showFrameRate = false;
        public static int magmaBGFrame = 0;
        public static int magmaBGFrameCounter = 0;
        public static int saveTimer = 0;
        public static bool autoJoin = false;
        public static bool serverStarting = false;
        public static float leftWorld = 0f;
        public static float rightWorld = 134400f;
        public static float topWorld = 0f;
        public static float bottomWorld = 38400f;
        public static int maxTilesX = (int)Main.rightWorld / 16 + 1;
        public static int maxTilesY = (int)Main.bottomWorld / 16 + 1;
        public static int maxSectionsX = Main.maxTilesX / 200;
        public static int maxSectionsY = Main.maxTilesY / 150;
        public static int numDust = 6000;
        public static int numPlayers = 0;
        public static int maxNetPlayers = 255;
        public static int maxRain = 750;

        public static float cameraX = 0f;
        public static bool drewLava = false;
        public static float[] liquidAlpha = new float[12];
        public static int waterStyle = 0;
        public static int worldRate = 1;
        public static float caveParrallax = 1f;
        public static int dungeonX;
        public static int dungeonY;
        public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
        public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
        public static bool dedServ = false;
        public static int spamCount = 0;
        public static int curMusic = 0;
        public static int dayMusic = 0;
        public static int ugMusic = 0;

        public static bool showItemText = true;
        public static bool autoSave = true;
        public static bool validateSaves = true;
        public static string buffString = "";
        public static string libPath = "";
        public static int lo = 0;
        public static int LogoA = 255;
        public static int LogoB = 0;
        public static bool LogoT = false;
        public static string statusText = "";
        public static string worldName = "";
        public static int worldID;
        public static int background = 0;
        public static int caveBackground = 0;
        public static float ugBackTransition = 0f;
        public static Color tileColor;
        public static double worldSurface;
        public static double rockLayer;
        public static Color[] teamColor = new Color[5];
        public static bool dayTime = true;
        public static double time = 13500.0;
        public static int moonPhase = 0;
        public static short sunModY = 0;
        public static short moonModY = 0;
        public static bool grabSky = false;
        public static bool bloodMoon = false;
        public static bool pumpkinMoon = false;
        public static bool snowMoon = false;
        public static float cloudAlpha = 0f;
        public static float maxRaining = 0f;
        public static float oldMaxRaining = 0f;
        public static int rainTime = 0;
        public static bool raining = false;
        public static bool eclipse = false;
        public static float eclipseLight = 0f;
        public static int checkForSpawns = 0;
        public static int helpText = 0;
        public static bool autoGen = false;
        public static bool autoPause = false;
        public static int[] projFrames = new int[360];
        public static bool[] projPet = new bool[360];
        public static float demonTorch = 1f;
        public static int demonTorchDir = 1;
        public static int numStars;
        public static int weatherCounter = 0;
        public static int cloudLimit = 200;
        public static int numClouds = Main.cloudLimit;
        public static int numCloudsTemp = Main.numClouds;
        public static float windSpeedTemp = 0f;
        public static float windSpeed = 0f;
        public static float windSpeedSet = 0f;
        public static float windSpeedSpeed = 0f;
        public static Cloud[] cloud = new Cloud[200];
        public static bool resetClouds = true;
        public static int sandTiles;
        public static int evilTiles;
        public static int shroomTiles;
        public static float shroomLight;
        public static int snowTiles;
        public static int holyTiles;
        public static int waterCandles;
        public static int meteorTiles;
        public static int bloodTiles;
        public static int jungleTiles;
        public static int dungeonTiles;
        public static bool campfire;
        public static bool heartLantern;
        public static int fadeCounter = 0;
        public static float invAlpha = 1f;
        public static float invDir = 1f;
        [ThreadStatic]
        public static Random rand;
        public static Texture2D[] bannerTexture = new Texture2D[3];
        public static Texture2D[] npcHeadTexture = new Texture2D[22];
        public static Texture2D craftButtonTexture;
        public static Texture2D craftUpButtonTexture;
        public static Texture2D craftDownButtonTexture;
        public static Texture2D scrollLeftButtonTexture;
        public static Texture2D scrollRightButtonTexture;
        public static Texture2D frozenTexture;
        public static Texture2D magicPixel;
        public static Texture2D miniMapFrameTexture;
        public static Texture2D miniMapFrame2Texture;
        public static Texture2D[] miniMapButtonTexture = new Texture2D[3];
        public static Texture2D[] destTexture = new Texture2D[3];
        public static Texture2D[] gemTexture = new Texture2D[6];
        public static Texture2D[] rudolphTexture = new Texture2D[3];
        public static Texture2D[] wingsTexture = new Texture2D[25];
        public static Texture2D[] armorHeadTexture = new Texture2D[160];
        public static Texture2D[] armorBodyTexture = new Texture2D[168];
        public static Texture2D[] femaleBodyTexture = new Texture2D[168];
        public static Texture2D[] armorArmTexture = new Texture2D[168];
        public static Texture2D[] armorLegTexture = new Texture2D[103];
        public static Texture2D[] accHandsOnTexture = new Texture2D[18];
        public static Texture2D[] accHandsOffTexture = new Texture2D[11];
        public static Texture2D[] accBackTexture = new Texture2D[8];
        public static Texture2D[] accFrontTexture = new Texture2D[5];
        public static Texture2D[] accShoesTexture = new Texture2D[15];
        public static Texture2D[] accWaistTexture = new Texture2D[11];
        public static Texture2D[] accShieldTexture = new Texture2D[5];
        public static Texture2D[] accNeckTexture = new Texture2D[7];
        public static Texture2D[] accFaceTexture = new Texture2D[8];
        public static Texture2D[] accBalloonTexture = new Texture2D[11];
        public static Texture2D pulleyTexture;
        public static Texture2D[] xmasTree = new Texture2D[5];
        public static Texture2D[] FlameTexture = new Texture2D[13];
        public static Texture2D timerTexture;
        public static Texture2D reforgeTexture;
        public static Texture2D wallOutlineTexture;
        public static Texture2D actuatorTexture;
        public static Texture2D wireTexture;
        public static Texture2D wire2Texture;
        public static Texture2D wire3Texture;
        public static Texture2D flyingCarpetTexture;
        public static Texture2D gridTexture;
        public static Texture2D lightDiscTexture;
        public static Texture2D EyeLaserTexture;
        public static Texture2D BoneEyesTexture;
        public static Texture2D BoneLaserTexture;
        public static Texture2D trashTexture;
        public static Texture2D chainTexture;
        public static Texture2D beetleTexture;
        public static Texture2D probeTexture;
        public static Texture2D xmasLightTexture;
        public static Texture2D[] golemTexture = new Texture2D[4];
        public static Texture2D confuseTexture;
        public static Texture2D[] gemChainTexture = new Texture2D[7];
        public static Texture2D sunOrbTexture;
        public static Texture2D sunAltarTexture;
        public static Texture2D chain2Texture;
        public static Texture2D chain3Texture;
        public static Texture2D chain4Texture;
        public static Texture2D chain5Texture;
        public static Texture2D chain6Texture;
        public static Texture2D chain7Texture;
        public static Texture2D chain8Texture;
        public static Texture2D chain9Texture;
        public static Texture2D chain10Texture;
        public static Texture2D chain11Texture;
        public static Texture2D chain12Texture;
        public static Texture2D chain13Texture;
        public static Texture2D chain14Texture;
        public static Texture2D chain15Texture;
        public static Texture2D chain16Texture;
        public static Texture2D chain17Texture;
        public static Texture2D chain18Texture;
        public static Texture2D chain19Texture;
        public static Texture2D chain20Texture;
        public static Texture2D chain21Texture;
        public static Texture2D chain22Texture;
        public static Texture2D chain23Texture;
        public static Texture2D chain24Texture;
        public static Texture2D chain25Texture;
        public static Texture2D chain26Texture;
        public static Texture2D chain27Texture;
        public static Texture2D chain28Texture;
        public static Texture2D chain29Texture;
        public static Texture2D chain30Texture;
        public static Texture2D chain31Texture;
        public static Texture2D chain32Texture;
        public static Texture2D hbTexture1;
        public static Texture2D hbTexture2;
        public static Texture2D chaosTexture;
        public static Texture2D cdTexture;
        public static Texture2D wofTexture;
        public static Texture2D boneArmTexture;
        public static Texture2D boneArm2Texture;
        public static Texture2D pumpkingArmTexture;
        public static Texture2D pumpkingCloakTexture;
        public static Texture2D[] npcToggleTexture = new Texture2D[2];
        public static Texture2D[] HBLockTexture = new Texture2D[2];
        public static Texture2D[] buffTexture = new Texture2D[104];
        public static Texture2D[] itemTexture = new Texture2D[2289];
        public static Texture2D[] itemFlameTexture = new Texture2D[2289];
        public static Texture2D[] npcTexture = new Texture2D[369];
        public static Texture2D[] projectileTexture = new Texture2D[360];
        public static Texture2D[] goreTexture = new Texture2D[573];
        public static Texture2D[] BackPackTexture = new Texture2D[7];
        public static Texture2D[] rainTexture = new Texture2D[3];
        public static Texture2D cursorTexture;
        public static Texture2D dustTexture;
        public static Texture2D sunTexture;
        public static Texture2D sun2Texture;
        public static Texture2D sun3Texture;
        public static int maxMoons = 3;
        public static int moonType = 0;
        public static Texture2D[] moonTexture = new Texture2D[Main.maxMoons];
        public static Texture2D pumpkinMoonTexture;
        public static Texture2D snowMoonTexture;
        public static int numTileColors = 31;
        public static RenderTarget2D[,] tileAltTexture = new RenderTarget2D[314, Main.numTileColors];
        public static bool[,] tileAltTextureInit = new bool[314, Main.numTileColors];
        public static bool[,] tileAltTextureDrawn = new bool[314, Main.numTileColors];
        public static int numTreeStyles = 15;
        public static RenderTarget2D[,] treeTopAltTexture = new RenderTarget2D[Main.numTreeStyles, Main.numTileColors];
        public static RenderTarget2D[,] treeBranchAltTexture = new RenderTarget2D[Main.numTreeStyles, Main.numTileColors];
        public static bool[,] treeAltTextureInit = new bool[Main.numTreeStyles, Main.numTileColors];
        public static bool[,] treeAltTextureDrawn = new bool[Main.numTreeStyles, Main.numTileColors];
        public static bool[,] checkTreeAlt = new bool[Main.numTreeStyles, Main.numTileColors];
        public static RenderTarget2D[,] wallAltTexture = new RenderTarget2D[145, Main.numTileColors];
        public static bool[,] wallAltTextureInit = new bool[145, Main.numTileColors];
        public static bool[,] wallAltTextureDrawn = new bool[145, Main.numTileColors];
        public static Texture2D[] tileTexture = new Texture2D[314];
        public static Texture2D blackTileTexture;
        public static Texture2D[] wallTexture = new Texture2D[145];
        public static Texture2D[] backgroundTexture = new Texture2D[185];
        public static Texture2D[] cloudTexture = new Texture2D[22];
        public static Texture2D[] starTexture = new Texture2D[5];
        public static Texture2D[] liquidTexture = new Texture2D[12];
        public static Texture2D heartTexture;
        public static Texture2D heart2Texture;
        public static Texture2D manaTexture;
        public static Texture2D bubbleTexture;
        public static Texture2D flameTexture;
        public static Texture2D[] treeTopTexture = new Texture2D[Main.numTreeStyles];
        public static Texture2D[] treeBranchTexture = new Texture2D[Main.numTreeStyles];
        public static Texture2D[] woodTexture = new Texture2D[7];
        public static Texture2D shroomCapTexture;
        public static Texture2D inventoryBackTexture;
        public static Texture2D inventoryBack2Texture;
        public static Texture2D inventoryBack3Texture;
        public static Texture2D inventoryBack4Texture;
        public static Texture2D inventoryBack5Texture;
        public static Texture2D inventoryBack6Texture;
        public static Texture2D inventoryBack7Texture;
        public static Texture2D inventoryBack8Texture;
        public static Texture2D inventoryBack9Texture;
        public static Texture2D inventoryBack10Texture;
        public static Texture2D inventoryBack11Texture;
        public static Texture2D inventoryBack12Texture;
        public static Texture2D inventoryBack13Texture;
        public static Texture2D inventoryBack14Texture;
        public static Texture2D hairStyleBackTexture;
        public static Texture2D clothesStyleBackTexture;
        public static Texture2D inventoryTickOnTexture;
        public static Texture2D inventoryTickOffTexture;
        public static Texture2D loTexture;
        public static Texture2D logoTexture;
        public static Texture2D logo2Texture;
        public static Texture2D textBackTexture;
        public static Texture2D chatTexture;
        public static Texture2D chat2Texture;
        public static Texture2D chatBackTexture;
        public static Texture2D teamTexture;
        public static Texture2D reTexture;
        public static Texture2D raTexture;
        public static Texture2D splashTexture;
        public static Texture2D fadeTexture;
        public static Texture2D ninjaTexture;
        public static Texture2D antLionTexture;
        public static Texture2D spikeBaseTexture;
        public static Texture2D ghostTexture;
        public static Texture2D evilCactusTexture;
        public static Texture2D goodCactusTexture;
        public static Texture2D crimsonCactusTexture;
        public static Texture2D wraithEyeTexture;
        public static Texture2D fireflyTexture;
        public static Texture2D fireflyJarTexture;
        public static Texture2D lightningbugTexture;
        public static Texture2D lightningbugJarTexture;
        public static Texture2D glowSnailTexture;
        public static Texture2D iceQueenTexture;
        public static Texture2D santaTankTexture;
        public static Texture2D reaperEyeTexture;
        public static Texture2D jackHatTexture;
        public static Texture2D treeFaceTexture;
        public static Texture2D pumpkingFaceTexture;
        public static Texture2D skinArmTexture;
        public static Texture2D skinBodyTexture;
        public static Texture2D skinLegsTexture;
        public static Texture2D playerEyeWhitesTexture;
        public static Texture2D playerEyesTexture;
        public static Texture2D playerHandsTexture;
        public static Texture2D playerHands2Texture;
        public static Texture2D playerHeadTexture;
        public static Texture2D playerPantsTexture;
        public static Texture2D playerShirtTexture;
        public static Texture2D playerShoesTexture;
        public static Texture2D playerUnderShirtTexture;
        public static Texture2D playerUnderShirt2Texture;
        public static Texture2D femaleShirt2Texture;
        public static Texture2D femalePantsTexture;
        public static Texture2D femaleShirtTexture;
        public static Texture2D femaleShoesTexture;
        public static Texture2D femaleUnderShirtTexture;
        public static Texture2D femaleUnderShirt2Texture;
        public static Texture2D[] playerHairTexture = new Texture2D[123];
        public static Texture2D[] playerHairAltTexture = new Texture2D[123];
        
        public static SpriteFont fontItemStack;
        public static SpriteFont fontMouseText;
        public static SpriteFont fontDeathText;
        public static SpriteFont[] fontCombatText = new SpriteFont[2];
        public static bool[] tileLighted = new bool[314];
        public static bool[] tileMergeDirt = new bool[314];
        public static bool[] tileCut = new bool[314];
        public static bool[] tileAlch = new bool[314];
        public static int[] tileShine = new int[314];
        public static bool[] tileShine2 = new bool[314];
        public static bool[] wallHouse = new bool[145];
        public static bool[] wallDungeon = new bool[145];
        public static bool[] wallLight = new bool[145];
        public static int[] wallBlend = new int[145];
        public static bool[] tileStone = new bool[314];
        public static bool[] tilePick = new bool[314];
        public static bool[] tileAxe = new bool[314];
        public static bool[] tileHammer = new bool[314];
        public static bool[] tileWaterDeath = new bool[314];
        public static bool[] tileLavaDeath = new bool[314];
        public static bool[] tileTable = new bool[314];
        public static bool[] tileBlockLight = new bool[314];
        public static bool[] tileNoSunLight = new bool[314];
        public static bool[] tileDungeon = new bool[314];
        public static bool[] tileSolidTop = new bool[314];
        public static bool[] tileSolid = new bool[314];
        public static byte[] tileLargeFrames = new byte[314];
        public static bool[] tileRope = new bool[314];
        public static bool[] tileBrick = new bool[314];
        public static bool[] tileMoss = new bool[314];
        public static bool[] tileNoAttach = new bool[314];
        public static bool[] tileNoFail = new bool[314];
        public static bool[] tileObsidianKill = new bool[314];
        public static bool[] tileFrameImportant = new bool[314];
        public static int cageFrames = 25;
        public static bool critterCage = false;
        public static int[] bunnyCageFrame = new int[Main.cageFrames];
        public static int[] bunnyCageFrameCounter = new int[Main.cageFrames];
        public static int[] squirrelCageFrame = new int[Main.cageFrames];
        public static int[] squirrelCageFrameCounter = new int[Main.cageFrames];
        public static int[] mallardCageFrame = new int[Main.cageFrames];
        public static int[] mallardCageFrameCounter = new int[Main.cageFrames];
        public static int[] duckCageFrame = new int[Main.cageFrames];
        public static int[] duckCageFrameCounter = new int[Main.cageFrames];
        public static int[] birdCageFrame = new int[Main.cageFrames];
        public static int[] birdCageFrameCounter = new int[Main.cageFrames];
        public static int[] redBirdCageFrame = new int[Main.cageFrames];
        public static int[] redBirdCageFrameCounter = new int[Main.cageFrames];
        public static int[] blueBirdCageFrame = new int[Main.cageFrames];
        public static int[] blueBirdCageFrameCounter = new int[Main.cageFrames];
        public static byte[,] butterflyCageMode = new byte[8, Main.cageFrames];
        public static int[,] butterflyCageFrame = new int[8, Main.cageFrames];
        public static int[,] butterflyCageFrameCounter = new int[8, Main.cageFrames];
        public static int[,] scorpionCageFrame = new int[2, Main.cageFrames];
        public static int[,] scorpionCageFrameCounter = new int[2, Main.cageFrames];
        public static int[] snailCageFrame = new int[Main.cageFrames];
        public static int[] snailCageFrameCounter = new int[Main.cageFrames];
        public static int[] snail2CageFrame = new int[Main.cageFrames];
        public static int[] snail2CageFrameCounter = new int[Main.cageFrames];
        public static byte[] fishBowlFrameMode = new byte[Main.cageFrames];
        public static int[] fishBowlFrame = new int[Main.cageFrames];
        public static int[] fishBowlFrameCounter = new int[Main.cageFrames];
        public static int[] frogCageFrame = new int[Main.cageFrames];
        public static int[] frogCageFrameCounter = new int[Main.cageFrames];
        public static int[] mouseCageFrame = new int[Main.cageFrames];
        public static int[] mouseCageFrameCounter = new int[Main.cageFrames];
        public static int[] wormCageFrame = new int[Main.cageFrames];
        public static int[] wormCageFrameCounter = new int[Main.cageFrames];
        public static int[] penguinCageFrame = new int[Main.cageFrames];
        public static int[] penguinCageFrameCounter = new int[Main.cageFrames];
        public static bool[] tileSand = new bool[314];
        public static bool[] tileFlame = new bool[314];
        public static bool[] npcCatchable = new bool[369];
        public static int[] tileFrame = new int[314];
        public static int[] tileFrameCounter = new int[314];
        public static byte[] wallFrame = new byte[145];
        public static byte[] wallFrameCounter = new byte[145];
        public static int[] backgroundWidth = new int[185];
        public static int[] backgroundHeight = new int[185];
        public static bool tilesLoaded = false;
        public static Map[,] map = new Map[Main.maxTilesX, Main.maxTilesY];
        public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];
        public static Dust[] dust = new Dust[6001];
        public static Star[] star = new Star[130];
        public static Item[] item = new Item[1001];
        public static int itemLimit = 1000;
        public static NPC[] npc = new NPC[201];
        public static Gore[] gore = new Gore[501];
        public static Rain[] rain = new Rain[Main.maxRain + 1];
        public static Projectile[] projectile = new Projectile[1001];
        public static CombatText[] combatText = new CombatText[100];
        public static ItemText[] itemText = new ItemText[20];
        public static Chest[] chest = new Chest[1000];
        public static Sign[] sign = new Sign[1000];
        public static Vector2 screenPosition;
        public static Vector2 screenLastPosition;
        public static int screenWidth = 1152;
        public static int screenHeight = 864;
        public static bool screenMaximized = false;
        public static int chatLength = 600;
        public static bool chatMode = false;
        public static bool chatRelease = false;
        public static int showCount = 10;
        public static int numChatLines = 500;
        public static int startChatLine = 0;
        public static string chatText = "";
        public static ChatLine[] chatLine = new ChatLine[Main.numChatLines];
        public static bool inputTextEnter = false;
        public static bool inputTextEscape = false;
        public static float[] hotbarScale = new float[]
		{
			1f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f
		};
        public static byte mouseTextColor = 0;
        public static int mouseTextColorChange = 1;
        public static bool mouseLeftRelease = false;
        public static bool mouseRightRelease = false;
        public static bool playerInventory = false;
        public static int stackSplit;
        public static int stackCounter = 0;
        public static int stackDelay = 7;
        public static int superFastStack = 0;
        public static Item mouseItem = new Item();
        public static Item guideItem = new Item();
        public static Item reforgeItem = new Item();
        private static float inventoryScale = 0.75f;
        public static bool hasFocus = true;
        public static bool recFastScroll = false;
        public static bool recBigList = false;
        public static int recStart = 0;
        public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];
        public static int[] availableRecipe = new int[Recipe.maxRecipes];
        public static float[] availableRecipeY = new float[Recipe.maxRecipes];
        public static int numAvailableRecipes;
        public static int focusRecipe;
        public static int myPlayer = 0;
        public static Player[] player = new Player[256];
        public static int spawnTileX;
        public static int spawnTileY;
        public static bool npcChatRelease = false;
        public static bool editSign = false;
        public static bool editChest = false;
        public static bool blockInput = false;
        public static Microsoft.Xna.Framework.Input.Keys blockKey = Microsoft.Xna.Framework.Input.Keys.None;
        public static string defaultChestName = string.Empty;
        public static string npcChatText = "";
        public static bool npcChatFocus1 = false;
        public static bool npcChatFocus2 = false;
        public static bool npcChatFocus3 = false;
        public static int npcShop = 0;
        public static int numShops = 20;

        public static int[] travelShop = new int[Chest.maxItems];
        public static bool craftGuide = false;
        public static bool reforge = false;
        private static Item toolTip = new Item();
        private static int backSpaceCount = 0;
        public static string motd = "";
        public static bool toggleFullscreen;
        public static int numDisplayModes = 0;
        public static int[] displayWidth = new int[99];
        public static int[] displayHeight = new int[99];
        public static bool gameMenu = true;
        private static int maxLoadPlayer = 1000;
        private static int maxLoadWorld = 1000;
        public static Player[] loadPlayer = new Player[Main.maxLoadPlayer];
        public static string[] loadPlayerPath = new string[Main.maxLoadPlayer];
        private static int numLoadPlayers = 0;
        public static string playerPathName;
        public static string[] loadWorld = new string[Main.maxLoadWorld];
        public static string[] loadWorldPath = new string[Main.maxLoadWorld];
        private static int numLoadWorlds = 0;
        public static string worldPathName;
        public static string SavePath = string.Concat(new object[]
		{
			Environment.GetFolderPath(Environment.SpecialFolder.Personal),
			Path.DirectorySeparatorChar,
			"My Games",
			Path.DirectorySeparatorChar,
			"TerrariaAdam"
		});
        public static string WorldPath = Main.SavePath + Path.DirectorySeparatorChar + "Worlds";
        public static string PlayerPath = Main.SavePath + Path.DirectorySeparatorChar + "Players";
        public static string[] itemName = new string[2289];
        public static string[] npcName = new string[369];
        private static KeyboardState inputText;
        private static KeyboardState oldInputText;
        public static int invasionType = 0;
        public static double invasionX = 0.0;
        public static int invasionSize = 0;
        public static int invasionDelay = 0;
        public static int invasionWarn = 0;
        public static int[] npcFrameCount = new int[]
		{
			1,
			2,
			2,
			3,
			6,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			16,
			14,
			16,
			14,
			15,
			16,
			2,
			10,
			1,
			16,
			16,
			16,
			3,
			1,
			15,
			3,
			1,
			3,
			1,
			1,
			16,
			16,
			1,
			1,
			1,
			3,
			3,
			15,
			3,
			7,
			7,
			4,
			5,
			5,
			5,
			3,
			3,
			16,
			6,
			3,
			6,
			6,
			2,
			5,
			3,
			2,
			7,
			7,
			4,
			2,
			8,
			1,
			5,
			1,
			2,
			4,
			16,
			5,
			4,
			4,
			15,
			15,
			15,
			15,
			2,
			4,
			6,
			6,
			24,
			16,
			1,
			1,
			1,
			1,
			1,
			1,
			4,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			5,
			6,
			7,
			16,
			1,
			1,
			16,
			16,
			12,
			20,
			21,
			1,
			2,
			2,
			3,
			6,
			1,
			1,
			1,
			15,
			4,
			11,
			1,
			14,
			6,
			6,
			3,
			1,
			2,
			2,
			1,
			3,
			4,
			1,
			2,
			1,
			4,
			2,
			1,
			15,
			3,
			16,
			4,
			5,
			7,
			3,
			2,
			12,
			12,
			4,
			4,
			4,
			8,
			8,
			9,
			2,
			6,
			4,
			15,
			16,
			3,
			3,
			8,
			5,
			4,
			3,
			15,
			12,
			4,
			14,
			14,
			3,
			2,
			5,
			3,
			2,
			3,
			14,
			5,
			14,
			16,
			5,
			2,
			2,
			12,
			3,
			3,
			3,
			3,
			2,
			2,
			2,
			2,
			2,
			7,
			14,
			15,
			16,
			8,
			3,
			15,
			15,
			15,
			2,
			3,
			20,
			16,
			14,
			16,
			4,
			4,
			16,
			16,
			20,
			20,
			20,
			2,
			2,
			2,
			2,
			8,
			12,
			3,
			4,
			2,
			4,
			16,
			16,
			15,
			6,
			3,
			3,
			3,
			3,
			3,
			3,
			4,
			4,
			5,
			4,
			6,
			7,
			15,
			4,
			7,
			6,
			1,
			1,
			2,
			4,
			3,
			5,
			3,
			3,
			3,
			4,
			5,
			6,
			4,
			2,
			1,
			8,
			4,
			4,
			1,
			8,
			1,
			4,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			3,
			3,
			3,
			3,
			3,
			3,
			15,
			3,
			6,
			12,
			20,
			20,
			20,
			15,
			15,
			15,
			5,
			5,
			6,
			6,
			5,
			2,
			7,
			2,
			6,
			6,
			6,
			6,
			6,
			15,
			15,
			15,
			15,
			15,
			11,
			4,
			2,
			2,
			3,
			3,
			3,
			15,
			15,
			15,
			10,
			14,
			12,
			1,
			10,
			8,
			3,
			3,
			2,
			2,
			2,
			2,
			7,
			15,
			15,
			15,
			6,
			3,
			10,
			10,
			6,
			9,
			8,
			9,
			8,
			20,
			10,
			6,
			14,
			1,
			4,
			24,
			2,
			4,
			6,
			6,
			10,
			15,
			15,
			15,
			15,
			4,
			4,
			16
		};
        private static bool mouseExit = false;
        private static float exitScale = 0.8f;
        private static bool mouseReforge = false;
        private static float reforgeScale = 0.8f;
        public static Player clientPlayer = new Player();
        public static string getIP = Main.defaultIP;
        public static string getPort = Convert.ToString(Netplay.serverPort);
        public static bool menuMultiplayer = false;
        public static bool menuServer = false;
        public static int netMode = 0;
        public static int timeOut = 120;
        public static int netPlayCounter;
        public static int lastNPCUpdate;
        public static int lastItemUpdate;
        public static int maxNPCUpdates = 5;
        public static int maxItemUpdates = 5;

        public static Color mouseColor = new Color(255, 50, 95);
        public static Color cursorColor = Color.White;
        public static int cursorColorDirection = 1;
        public static float cursorAlpha = 0f;
        public static float cursorScale = 0f;
        public static bool signBubble = false;
        public static int signX = 0;
        public static int signY = 0;
        public static bool hideUI = false;
        public static bool releaseUI = false;
        public static bool fixedTiming = false;

        public static string oldStatusText = "";
        public static bool autoShutdown = false;
        public static float ambientWaterfallX = -1f;
        public static float ambientWaterfallY = -1f;
        public static float ambientWaterfallStrength = 0f;
        public static float ambientLavafallX = -1f;
        public static float ambientLavafallY = -1f;
        public static float ambientLavafallStrength = 0f;
        public static float ambientLavaX = -1f;
        public static float ambientLavaY = -1f;
        public static float ambientLavaStrength = 0f;
        public static int ambientCounter = 0;

        public static string newWorldName = "";
        public static bool blockMouse = false;

        private static int maxMenuItems = 14;
        public static int menuMode = 0;
        public static int menuSkip = 0;
        private static Item cpItem = new Item();

        private static int dyeSlotCount = 0;
        private static int accSlotCount = 0;
        private static string hoverItemName = "";
        private static Color inventoryBack = new Color(220, 220, 220, 220);
        private static bool mouseText = false;
        private static int mH = 0;
        private static int sX = Main.screenWidth - 800;
        private static int starMana = 20;
        private static float heartLife = 20f;
        private static int rare = 0;
        private static int hairStart = 0;
        private static int oldHairStyle;
        private static Color oldHairColor;
        private static int selClothes = 0;
        private static Color[] oldClothesColor = new Color[4];
        public static int dresserX;
        public static int dresserY;
        public static Color selColor = Color.White;
        public static int focusColor = 0;
        public static int colorDelay = 0;
        public static int setKey = -1;
        public static int bgScroll = 0;
        public static bool autoPass = false;
        public static int menuFocus = 0;
        private static float hBar = -1f;
        private static float sBar = -1f;
        private static float lBar = 1f;

        private static float tranSpeed = 0.05f;
        private static float atmo = 0f;
        private static float bgScale = 1f;
        private static int bgW = (int)(1024f * Main.bgScale);
        private static Color backColor = Color.White;
        private static Color trueBackColor = Main.backColor;

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int keyCode);
    }
}
