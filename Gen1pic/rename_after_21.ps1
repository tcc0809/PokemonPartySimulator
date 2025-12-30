# 警告：這個腳本只會處理編號大於 21 的 .png 檔案，並將其減 1

# 設定起始 ID (處理的範圍：數字 > 21)
$startID = 21

# 找到資料夾內所有 .png 檔案
Get-ChildItem -Filter "*.png" | ForEach-Object {
    
    # 【修正 1】擷取「無副檔名」的純數字部分 (例如從 "22.png" 得到 "22")
    $baseName = $_.BaseName
    
    # 宣告一個變數來存放轉換結果
    $number = 0 
    
    # 嘗試將其轉換為數字 (使用 [int]::TryParse() 判斷是否為數字)
    if ([int]::TryParse($baseName, [ref]$number)) {
        
        # 判斷是否在我們想處理的範圍內 (數字大於 21 且小於等於 152)
        if ($number -gt $startID -and $number -le 152) {
            
            # 進行減一運算 (22 變成 21)
            $newNumber = $number - 1
            
            # 組合新的檔名 (例如 "21.png")
            $newName = "$newNumber" + $_.Extension
            
            # 執行重新命名
            Rename-Item -Path $_.FullName -NewName $newName
            
            Write-Host "已將 $($_.Name) 重新命名為 $newName"
        } else {
            # 略過你手動改的 1~21 號檔案
            Write-Host "略過檔案: $($_.Name) - 在手動範圍內 (1-21)"
        }
    } else {
        # 略過非數字開頭的檔案
        Write-Host "略過檔案: $($_.Name) - 非純數字開頭"
    }
}

Write-Host "--------------------"
Write-Host "批次重新命名完成。"