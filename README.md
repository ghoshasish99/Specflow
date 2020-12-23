# Specflow
Specflow

### Test Execution Task in Azure DevOps

```steps:
- task: VSTest@2
  displayName: 'Execute Tests'
  inputs:
    testAssemblyVer2: |
     **\AzureWorkshop.dll
     !**\*TestAdapter.dll
     !**\obj\**
    testFiltercriteria: 'TestCategory=UITest'
