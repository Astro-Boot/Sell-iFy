
using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using Sellify.Application.Contracts.Infrasctructure;
using Sellify.Application.Models.ImageManagement;

namespace Sellify.Infrastructure.ImageCloudinary;

public class ManageImageService : IManageImageService
{

    public CloudinarySettings _cloudinarySettings {get;}

    public ManageImageService(IOptions<CloudinarySettings> cloudinarySettings)
    {
        _cloudinarySettings = cloudinarySettings.Value;
    }
    public async Task<ImageResponse> UploadImage(ImageData imageStream)
    {
        var account = new Account(
            _cloudinarySettings.CloudName,
            _cloudinarySettings.ApiKey,
            _cloudinarySettings.ApiSecret
        );

        var cloudinary = new Cloudinary(account);

        var uploadImage = new ImageUploadParams()
        {
            File = new FileDescription(imageStream.Nombre, imageStream.ImageStream)
        };

        var uploadResult = await cloudinary.UploadAsync(uploadImage);

        if (uploadResult.StatusCode == HttpStatusCode.OK)
        {
            return new ImageResponse {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.Url.ToString()
            };
        }

        throw new Exception("La imagen no se guardo");
    }


}