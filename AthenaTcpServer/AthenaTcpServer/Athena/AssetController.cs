using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Storage;

namespace AthenaTcpServer
{
    class AssetController
    {
        List<StorageFile> DoorBellSound;
        MediaPlayer MediaPlayer;


        private bool IsAssetsLoad = false;

        public AssetController()
        {
            Debug.WriteLine("AssetController: ");
            DoorBellSound = new List<StorageFile>();
            MediaPlayer player = BackgroundMediaPlayer.Current;
            player.AutoPlay = false;
            Task<bool> result = LoadAssetAsync();
            result.Wait();

            // Tast the first sound
            PlayerAsset(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LoadAssetAsync()
        {
            Debug.WriteLine("AssetController: LoadAssetAsync ");
            StorageFile loadingAudioSource;
            // Loading assets
            Debug.WriteLine(Config.Athena_DoorBell_Sound_Path);

            try
            {
                Debug.WriteLine("Start");
                loadingAudioSource =  await StorageFile.GetFileFromApplicationUriAsync(new Uri(Config.Athena_DoorBell_Sound_Path));
                Debug.WriteLine("Complete");
                DoorBellSound.Add(loadingAudioSource);
                IsAssetsLoad = true;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("AssetController: LoadAssetAsync Error");
                Debug.WriteLine(e.Message);
                return false;
            }
        }



        public void PlayerAsset(int _assetIndex)
        {
            if (IsAssetsLoad)
            {
                Debug.WriteLine("AssetController: PlayerAsset " + _assetIndex);
                if(DoorBellSound[_assetIndex] != null)
                {
                    MediaPlayer.SetFileSource(DoorBellSound[_assetIndex]);
                    MediaPlayer.Play();
                }

            }
        }

    }
}
