using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MonitoringApi.HealthChecks;

public class RandomHealChecks : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        int responseTineInMs = Random.Shared.Next(300);

        if (responseTineInMs < 100)
        {
            return Task.FromResult(HealthCheckResult.Healthy($"The response time is excellent({responseTineInMs})"));
        }else if (responseTineInMs < 200)
        {
            return Task.FromResult(HealthCheckResult.Degraded($"The response time is excellent({responseTineInMs})"));
        }
        else
        {
            return Task.FromResult(HealthCheckResult.Unhealthy($"The response time is excellent({responseTineInMs})"));
        }
    }
}
 