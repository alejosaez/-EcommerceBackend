using EcommerceBackend.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BlobController : ControllerBase
{
    private readonly BlobStorageService _blobStorageService;

    public BlobController(BlobStorageService blobStorageService)
    {
        _blobStorageService = blobStorageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadBlob(IFormFile file, string containerName)
    {
        using var stream = file.OpenReadStream();
        await _blobStorageService.UploadBlobAsync(containerName, file.FileName, stream);
        return Ok("Archivo subido exitosamente.");
    }

    [HttpGet("download")]
    public async Task<IActionResult> DownloadBlob(string containerName, string blobName)
    {
        var stream = await _blobStorageService.DownloadBlobAsync(containerName, blobName);
        return File(stream, "application/octet-stream", blobName);
    }
}