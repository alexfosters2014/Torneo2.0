using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImageService
    {
        public async Task<string> UploadImage(string keyAzureBlob, string storageNameAzureBlob, byte[] imagen)
        {
            try
            {
                var imagenStream = new MemoryStream();
                await imagenStream.WriteAsync(imagen);
                imagenStream.Position = 0;

                string imageName = Guid.NewGuid().ToString() + ".jpg";

                BlobContainerClient blobContainer = new BlobContainerClient(keyAzureBlob, storageNameAzureBlob);
                var blob = blobContainer.GetBlobClient(imageName);

                await blob.UploadAsync(imagenStream);

                return imageName;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateImage(string keyAzureBlob, string storageNameAzureBlob, byte[] imagen, string nombreArchivo)
        {
            try
            {
                var imagenStream = new MemoryStream();
                await imagenStream.WriteAsync(imagen);
                imagenStream.Position = 0;

                string imageName = Guid.NewGuid().ToString() + ".jpg";

                BlobContainerClient blobContainer = new BlobContainerClient(keyAzureBlob, storageNameAzureBlob);


                var blobAEliminar = blobContainer.GetBlobClient(nombreArchivo);
                await EliminarImagen(blobAEliminar);


                var blob = blobContainer.GetBlobClient(imageName);
                await blob.UploadAsync(imagenStream);

                return imageName;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task EliminarImagen(BlobClient blob)
        {
            try
            {
                await blob.DeleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
