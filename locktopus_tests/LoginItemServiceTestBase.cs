using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using locktopus_domain.Entities;
using locktopus_domain.Repositories;
using locktopus_domain.Services;
using locktopus_tests.Mocks.Repositories;

namespace locktopus_tests;

public class LoginItemServiceTestBase
{
    public Mock<ILoginItemRepository> MockRepository;
    public Mock<ILogger<LoginItemService>> MockLogger;
    public Mock<IConfiguration> MockConfiguration;
    public LoginItemService Service;
    
    [SetUp]
    public void Setup()
    {
        // Mock IConfiguration
        MockConfiguration = new Mock<IConfiguration>();
        MockConfiguration.Setup(config => config["EncryptionSecrets:Key"]).Returns("5cbw0sI/b8mrG8XE+6n+WvUWqJNuzsTKCSSOfK2oxNI=");
        MockConfiguration.Setup(config => config["EncryptionSecrets:IV"]).Returns("xWQpmTGjnOd9sf1wbuhGww==");

        // Initialize the mock repository
        MockRepository = MockLoginItemRepository.GetMock("user123");

        // Mock logger
        MockLogger = new Mock<ILogger<LoginItemService>>();

        // Initialize the service with mocks
        // Service = new LoginItemService(MockRepository.Object, MockConfiguration.Object, MockLogger.Object);
    }
}