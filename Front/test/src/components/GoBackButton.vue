<template>
    <button @click="$router.go(-1)" class="goback">
        <svg>
            <use :xlink:href="require('@/assets/icons/sprite.svg') + '#gobackIcon'"></use>
        </svg>
        Назад
    </button>
</template>
<style lang="scss" scoped>
    .goback{
        color: #2192BF;
        font-weight: 600;
        font-size: 16px;
        line-height: 20px;
        display: flex;
        align-items: center;
        background: transparent;
        border: none;
        cursor: pointer;
        margin-top: 48px;
        margin-left: 48px;

        svg{
            width: 14px;
            height: 14px;
            margin-right: 9px;
        }
    }
</style>
