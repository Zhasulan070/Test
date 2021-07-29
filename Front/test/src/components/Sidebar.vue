<template>
    <div class="sidebar">
        <div class="sidebar__logo">
            <img src="/logo.png" alt="logo" />
        </div>
        <div class="sidebar__list">
            <div class="sidebar__item" v-for="(sidebar) in sidebarItems" :key="sidebar.id">
                <SidebarItem :item="sidebar" />
            </div>
        </div>
    </div>
</template>
<script>
    import SidebarItem from "./SidebarItem";

    export default {
        props: {
            sidebarItems: {
                type: Array,
                default: () => []
            },
        },
        components: {
            SidebarItem
        }
    }
</script>
<style lang="scss" scoped>
    .sidebar {
        padding: 18px 32px 0 77px;
        height: 100%;

        &__logo{
            text-align: center;
            margin-bottom: 28px;
        }

        &__item{
            margin-bottom: 5px;
        }
    }
</style>